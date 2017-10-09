using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectAndStuff
{
    public interface IFuel
    {
        string ToString();
        float Price { get; set; }
        int Level { get; set; }
        bool IsCompatible(IEngine engine);
    }
}
