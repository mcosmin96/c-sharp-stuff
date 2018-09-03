using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //AreArraysEqual();
            //ConvertingStuff();
            //QueueStuff();
            //PassingRefsThroughMethods();
            //WriteHistoricFiles();
            //ParseDateStrings();
            BytesStuff();
            Console.Read();
        }

        private static void BytesStuff()
        {
            var text = "aaabbbcccdddeeefffggghhhiiijjjkkklllmmmnnnooopppqqqrrrssstttuuuvvvwwwxxxyyyzzz";

            var bytes = ASCIIEncoding.ASCII.GetBytes(text);

            for (var i = 0; i < bytes.Length; i = i + 12)
            {
                var b = bytes.Skip(i).Take(12).ToArray();
            }
        }

        private static void ParseDateStrings()
        {
            try
            {
                //var a = DateTime.ParseExact("2018-04-13 11:52:53.521 some text");
            }
            catch (FormatException e)
            {

            }
        }

        private static void WriteHistoricFiles()
        {
            string output = "";

            for (var i = 0; i < 20; i++)
            {
                output += DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
                output += $" Test string {i}\r\n";
                Thread.Sleep(100);
            }

        }

        private static void PassingRefsThroughMethods()
        {
            var ao = new AnyObject { Number = 30 };

            DoSomething(ao);
            Console.WriteLine(ao.Number);
        }

        private static void DoSomething(AnyObject ao)
        {
            ao.Number++;
        }

        private static void QueueStuff()
        {
            var q = new Queue<qObject>();

            q.Enqueue(new qObject() { name = "asdf" });

            Console.WriteLine(q);

            q.Enqueue(new qObject() { name = "asdfgsdf" });

            Console.WriteLine(q.ToString());

            q.Dequeue();

            Console.WriteLine(q.ToString());
        }

        private static void ConvertingStuff()
        {
            Console.WriteLine(Convert.ToInt32(Convert.ToDouble("10.4")));
        }

        private static void AreArraysEqual()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 2, 3 };
            Console.WriteLine(a.SequenceEqual<int>(b));
        }
    }

    class qObject
    {
        public string name { get; set; }
    }

    class AnyObject
    {
        public int Number { get; set; }
    }
}
