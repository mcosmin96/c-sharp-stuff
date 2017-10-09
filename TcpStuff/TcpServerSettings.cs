namespace TcpStuff
{
   public class TcpServerSettings
    {
        public int ServerPort { get; set; }

        public TcpServerMode Mode;

        public enum TcpServerMode
        {
            Read,
            Write
        }

        public TcpServerSettings()
        {
            ServerPort = 48157;
            Mode = TcpServerMode.Write;
        }
    }
}