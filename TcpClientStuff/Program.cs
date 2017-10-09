using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TcpClient();
            client.Connect("localhost", 3434);
            client.GetStream().Write(ASCIIEncoding.ASCII.GetBytes("asd"), 0, 3);
            Console.Read();
        }
    }
}
