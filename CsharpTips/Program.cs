using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTips
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectDebuggerDisplay obj = new ObjectDebuggerDisplay();
            obj.ObjectType = "Cube";
            obj.ObjectSize = 3;

            Console.WriteLine(obj);

            //null stuff - instead of if null then else then:
            var name = "Sarah";
            var result = name ?? "no name";
            
            name = null;
            result = name ?? null ?? "no name"; //can chain it

            int? age = null; //? makes int nullable

            Console.Read();
        }
    }
}
