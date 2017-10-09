using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectAndStuff
{
    public class Petrol : IFuel
    {
        public string ToString() => "Petrol";

        private float _price;

        public float Price
        {
            get
            {
                if (_price == 0)
                    _price = 1.20f;
                return _price;
            }
            set { _price = value; }
        }

        private int _level;

        public int Level
        {
            get
            {
                if (_level == 0)
                    _level = 50;
                return _level;
            }
            set { _level = value; }
        }

        public bool IsCompatible(IEngine engine)
        {
            if (engine.GetType().Name.StartsWith("Petrol"))
                return true;
            return false;
        }

    }
}
