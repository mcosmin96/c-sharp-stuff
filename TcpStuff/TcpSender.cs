using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TcpStuff
{
    public class TcpSender
    {
        private readonly BlockingCollection<byte[]> queue = new BlockingCollection<byte[]>(50);

        public EventHandler Closed;

        private readonly TcpClient tcpClient;

        private CancellationTokenSource cancellationTokenSource;

        public TcpSender(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void AddToQueue(byte[] data)
        {
            queue.TryAdd(data, 250, cancellationTokenSource.Token);
        }

        public async Task Start()
        {
            var clientEndPoint = tcpClient.Client.RemoteEndPoint.ToString();

            try
            {
                using (var networkStream = tcpClient.GetStream())
                {
                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        try
                        {
                            var data = queue.Take(cancellationTokenSource.Token);
                            await networkStream.WriteAsync(data, 0, data.Length, cancellationTokenSource.Token);
                        }
                        catch (OperationCanceledException)
                        {
                            // Don't care
                        }
                        catch (Exception)
                        {
                            Debug.WriteLine("Unable to send to {0}. Disconnecting.", clientEndPoint);
                            break;
                        }
                    }
                }
            }
            finally
            {
                Closed?.Invoke(this, null); //what
            }
        }

        public void Stop()
        {
            cancellationTokenSource.Cancel();
        }
    }
}