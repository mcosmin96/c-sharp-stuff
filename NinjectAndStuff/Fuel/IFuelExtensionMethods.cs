using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectAndStuff.Fuel
{
    public static class IFuelExtensionMethods
    {
        public static void Refill(this IFuel fuel)
        {
            Console.WriteLine("Full tank!");
        }
    }
}
