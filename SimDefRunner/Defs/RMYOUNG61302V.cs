using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class RMYOUNG61302V // PeriodRange: 1800
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double Pressure = Convert.ToDouble(inputs["Pressure"]);

            return $"{Pressure:0000.00}\r\n";
        } //Runcode end

        //Private methods start


        //Private methods end
    }
}