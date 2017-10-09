namespace TcpStuff
{
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class SenderContext
    {
        public TcpSender TcpSender { get; set; }
        public Task TcpSenderTask { get; set; }

        public TcpReceiver TcpReceiver { get; set; }
        public Task TcpReceiverTask { get; set; }

        public TcpClient TcpClient { get; set; }
    }
}