using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TcpStuff
{
    public class TcpServer
    {
        private readonly List<SenderContext> tcpSenders = new List<SenderContext>();

        private CancellationTokenSource cancellationTokenSource;

        private TcpListener listener;

        public TcpServerSettings TcpSettings { get; set; }

        public event EventHandler<DataEventArgs> OnDataReceived;

        public async Task Start()
        {
            cancellationTokenSource = new CancellationTokenSource();

            while(!cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    await StartListenerAndWaitForConnections();
                }
                catch (Exception exception)
                {
                    int sleepTime = 1000;
                    StopListener();
                    Thread.Sleep(sleepTime);
                }
            }
        }

        private async Task StartListenerAndWaitForConnections()
        {
            listener = new TcpListener(new IPEndPoint(IPAddress.Any, TcpSettings.ServerPort));
            listener.Start();

            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    var client = await listener.AcceptTcpClientAsync();
                    Task.Run(() => AddClient(client));
                }
                catch (ObjectDisposedException)
                {
                    // Listener closed
                }
            }
        }

        private void StopListener()
        {

            try
            {
                listener?.Stop();
                listener = null;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        internal void Send(byte[] dataToSend)
        {
            Parallel.ForEach(tcpSenders, s => s.TcpSender.AddToQueue(dataToSend));
        }

        private void AddClient(TcpClient client)
        {
            TcpReceiver tcpReceiver = new TcpReceiver(client);
            tcpReceiver.OnData += OnDataReceivedFromTcp;

            var tcpContext = new SenderContext
            {
                TcpClient = client,
                TcpSender = new TcpSender(client),
                TcpReceiver = tcpReceiver
            };
            tcpContext.TcpSender.Closed += CloseClient;
            tcpContext.TcpReceiver.Closed += CloseClient;

            tcpSenders.Add(tcpContext);

            if (TcpSettings.Mode == TcpServerSettings.TcpServerMode.Write)
            {
                tcpContext.TcpSenderTask = tcpContext.TcpSender.Start();
            }
            else
            {
                tcpContext.TcpReceiverTask = tcpContext.TcpReceiver.Start();
            }
        }

        private void OnDataReceivedFromTcp(object sender, DataEventArgs e)
        {
            OnDataReceived?.Invoke(this, new DataEventArgs { Data = e.Data });
        }

        private void CloseClient(object sender, EventArgs e)
        {
            SenderContext tcpContext = tcpSenders.FirstOrDefault(c => c.TcpSender == sender);
            if (tcpContext != null)
                CloseTcpClient(tcpContext);
        }

        private void CloseTcpClient(SenderContext tcpContext)
        {
            tcpContext.TcpReceiver.Stop();
            tcpContext.TcpSender.Stop();
            tcpContext.TcpClient.Close();
            tcpSenders.Remove(tcpContext);
        }

        public void Stop()
        {
            cancellationTokenSource?.Cancel();
            CloseTcpClients();
            StopListener();
        }

        private void CloseTcpClients()
        {
            Parallel.ForEach(tcpSenders, CloseTcpClient);
            tcpSenders.Clear();
        }
    }
}