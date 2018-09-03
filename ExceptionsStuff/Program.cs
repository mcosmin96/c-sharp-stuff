using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            A();
            }
            catch (Exception e)
            {
                //
            }
        }

        private static void A()
        {
            B();
        }

        private static void B()
        {
            C.D();
        }
    }

    public class C
    {
        public static void D()
        {
            E.F.G();
        }
    }

}

namespace E
{
    public class F
    {
        public static void G()
        {
            H();
        }

        private static void H()
        {
            throw new NotImplementedException();
        }
    }
}
