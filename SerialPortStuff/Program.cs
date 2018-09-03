using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort Port = new SerialPort
            {
                PortName = SerialPort.GetPortNames()[0]
            };
            var pNames = SerialPort.GetPortNames();
        }
    }
}
