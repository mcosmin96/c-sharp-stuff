using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectAndStuff
{
    public class DieselEngine : IEngine
    {
        private IFuel _fuelType;

        public DieselEngine(IFuel fuel)
        {
            FuelType = fuel;
        }

        public IFuel FuelType { get => _fuelType; set => _fuelType = value; }

        public string ToString() => FuelType.ToString() + " Engine";
    }
}
