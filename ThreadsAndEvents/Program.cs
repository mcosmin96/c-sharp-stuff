using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndEvents
{
    class Program
    {
        static event EventHandler Event;
        static Thread RemoveThread;
        static Class Class;
        static void Main(string[] args)
        {
            RemoveThread = new Thread(Start_RemoveThread);
            Event += Program_Event;
            Class = new Class();
            RemoveThread.Start();
        }

        private static void Program_Event(object sender, EventArgs e)
        {
            Class.Remove("asd");
        }

        private static void Start_RemoveThread()
        {
            Event?.Invoke(null, null);
        }
    }
}
