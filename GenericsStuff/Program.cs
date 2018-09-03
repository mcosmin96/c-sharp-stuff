using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericsStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Type pType = typeof(GenericClass<int>);
            var input = 30;
            PropertyInfo pMinVal = pType.GetProperty("Property");
            GenericInterface parameter = Activator.CreateInstance(pType) as GenericInterface;
            
            parameter.Name = "3";
            PropertyInfo pName = pType.GetProperty("Name");
            parameter.PName.SetValue(parameter, "4");

            Console.WriteLine(parameter.Name);
        }
    }
}
