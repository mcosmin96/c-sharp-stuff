using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TcpStuff
{
    public class TcpReceiver
    {
        private readonly TcpClient tcpClient;
        private CancellationTokenSource cancellationTokenSource;
        public event EventHandler<DataEventArgs> OnData;
        public EventHandler Closed;
        private readonly byte[] readBuffer = new byte[2000];

        public TcpReceiver(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task Start()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    await ReadData();
                }
                catch (ObjectDisposedException)
                {
                    //connection closed
                }
                catch (Exception exception)
                {
                    //
                }
            }
        }

        private async Task ReadData()
        {
            if (tcpClient.Connected)
            {
                using (var stream = tcpClient.GetStream())
                {
                    while (!cancellationTokenSource.IsCancellationRequested)
                    {
                        var dataRead = await stream.ReadAsync(readBuffer, 0, readBuffer.Length, cancellationTokenSource.Token);

                        if (dataRead > 0)
                        {
                            OnData?.Invoke( this, new DataEventArgs { Data = readBuffer.Take(dataRead).ToArray() } );
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Closed?.Invoke(this, null);
        }

        public void Stop()
        {
            OnData = null;
            cancellationTokenSource.Cancel();
        }
    }
}