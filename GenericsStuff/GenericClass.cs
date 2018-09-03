using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericsStuff
{
    public class GenericClass<T> : GenericInterface
    {
        public T Property { get; set; }

        private PropertyInfo pName = typeof(GenericClass<T>).GetProperty("Property");

        public PropertyInfo PName { get; set; }
        public string Name
        {
            get; set;
        }






    }
}
