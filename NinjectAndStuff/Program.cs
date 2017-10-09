using NinjectAndStuff.Fuel; //namespace that the extension method is in
using System;

namespace NinjectAndStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Car vh = new Car(new PetrolEngine(new Petrol()));
            Car vw = new Car(new DieselEngine(new Diesel()));
            Console.WriteLine(vw.Engine.ToString());
            Console.WriteLine(vh.Engine.ToString());
            vh.Engine.FuelType.Refill();

            //funcs and lambdas

            Func<int, int, string> addToString = (x, y) => x.ToString() + y.ToString();
            Func<int, string> intToString = x =>
            {
                string res = x.ToString();
                return res; //you need to return in curlybraces
            };
            Console.WriteLine(addToString(1, 3));
            Console.WriteLine(intToString(13));
            Console.Read();

            One((a, b) => a + b);
            Two();
        }

        private static void Two()
        {
            int otherInt = 4;

            Func<int> returnOnly = new Func<int>(() => otherInt);

            Func<int,int,int> func = new Func<int,int,int>( (a,b) => a * b );
            func.Invoke(1,2);

            Action<int> act = new Action<int>( b =>  Console.WriteLine(b) );
            act.Invoke(3);
        }

        private static void One(Func<int,int,int> func)
        {
            func.Invoke(1, 1);
        }
    }
}
