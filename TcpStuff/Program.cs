using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TcpStuff
{
    public static class ExtensionMethods
    {
        public static byte[] ToAsciiBytes(this string text)
        {
            return ASCIIEncoding.ASCII.GetBytes(text);
        }
    }

    class Program
    {
        static TcpServer TcpServer;

        static BlockingCollection<byte[]> DataToTcp { get; set; }

        static void Main(string[] args)
        {
            DataToTcp = new BlockingCollection<byte[]>();
            StartTcpServer();
            StartTcpProcessorThread();
            Console.Read();
            Write();
        }

        private static void Write()
        {
            byte[] dataToSend = "Hello!".ToAsciiBytes();
            //byte[] receivedData = new byte[67];

            DataToTcp.Add(dataToSend); DataToTcp.Add(dataToSend);
        }

        private static void StartTcpProcessorThread()
        {
            Thread tcpProcessorThread = new Thread(TcpQueueProcessor);
            tcpProcessorThread.Start();
        }

        private static void TcpQueueProcessor(object client)
        {
            bool dataAvailable = true;
            do
            {
                try
                {
                    byte[] dataToSend;
                    dataAvailable = DataToTcp.TryTake(out dataToSend, Timeout.Infinite);
                    if (dataAvailable)
                    {
                        TcpServer.Send(dataToSend);
                    }
                    if (DataToTcp.IsCompleted)
                    {
                        dataAvailable = false;
                    }

                    EnforceMaxItemLimit(DataToTcp, 100000);
                }
                catch (InvalidOperationException)
                {
                    dataAvailable = false;
                }
                catch (Exception)
                {
                    //??
                }
            } while (dataAvailable);
        }

        public static void EnforceMaxItemLimit(BlockingCollection<byte[]> dataToTcp, int limit)
        {
            if (dataToTcp.Count > limit)
            {
                int itemsToRemove = dataToTcp.Count - limit;
                while (itemsToRemove > 0)
                {
                    byte[] item;
                    dataToTcp.TryTake(out item);
                    itemsToRemove--;
                }
            }
        }

        private static void StartTcpServer()
        {
            Thread tcpQueueThread = new Thread(StartTcpServerThread);
            tcpQueueThread.Start();
        }

        private static void StartTcpServerThread()
        {
            TcpServer = new TcpServer { TcpSettings = new TcpServerSettings() { ServerPort = 3002, Mode = TcpServerSettings.TcpServerMode.Write } };

            TcpServer.Start();
        }

    }
}
