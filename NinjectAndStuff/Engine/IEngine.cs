using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectAndStuff
{
    public interface IEngine
    {
        IFuel FuelType { get; set; }

        string ToString();
    }
}
