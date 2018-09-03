using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class ElevationOffset // PeriodRange: 1000, 2000, 60000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double ElevationOffset = Convert.ToDouble(inputs["ElevationOffset"]);

            return $"{ElevationOffset:0000.00}\r\n";
        } //Runcode end

        //Private methods start

        
        //Private methods end
    }
}