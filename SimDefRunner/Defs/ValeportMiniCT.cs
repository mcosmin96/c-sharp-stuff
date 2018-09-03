using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class ValeportMiniCT // PeriodRange: 1000, 2000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double Temperature = Convert.ToDouble(inputs["Temperature"]);
            double Conductivity = Convert.ToDouble(inputs["Conductivity"]);
            double Pressure = Convert.ToDouble(inputs["Pressure"]);
            bool PressureEnabled = Convert.ToBoolean(inputs["PressureEnabled"]);

            if (PressureEnabled)
            {
                return $"{Pressure:00.000}\t{Temperature:00.000}\t{Conductivity:00.000}\r\n";
            }
            else
            {
                return $"{Temperature:00.000}\t{Conductivity:00.000}\r\n";
            }
        } //Runcode end

        //Private methods start


        //Private methods end
    }
}