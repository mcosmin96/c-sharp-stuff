using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeTing
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartTime = DateTime.Now;

            DateTime SecondTime = StartTime.AddMinutes(15.01);
            TimeSpan Interval = SecondTime - StartTime;

            Console.WriteLine(StartTime);
            Console.WriteLine(SecondTime);

            Console.WriteLine(Interval.TotalSeconds % (15*60));

            Console.Read();
        }
    }
}
