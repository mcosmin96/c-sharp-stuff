using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectAndStuff
{
    public class Car
    {
        private IEngine _engine;

        public Car(IEngine engine)
        {
            Engine = engine;
        }
        public IEngine Engine { get => _engine; set => _engine = value; }
    }
}
