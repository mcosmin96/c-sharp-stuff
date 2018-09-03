using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTips
{
    [DebuggerDisplay("This is a {ObjectType} object with a size of {ObjectSize}")]
    public class ObjectDebuggerDisplay
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] //makes it not appear in the debug props
        public string ObjectType { get; set; }

        [DebuggerDisplay("{ObjectSize} m^3")]
        public int ObjectSize { get; set; }
    }
}
