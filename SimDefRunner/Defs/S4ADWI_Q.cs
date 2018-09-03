using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class S4ADWI_Q // PeriodRange: 1000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double Vn = Convert.ToDouble(inputs["Vn"]);
            double Ve = Convert.ToDouble(inputs["Ve"]);
            double CompassX = Convert.ToDouble(inputs["CompassX"]);
            double CompassY = Convert.ToDouble(inputs["CompassY"]);
            double SeaTemp = Convert.ToDouble(inputs["SeaTemp"]);
            double Depth = Convert.ToDouble(inputs["Depth"]);
            double TiltX = Convert.ToDouble(inputs["TiltX"]);
            double TiltY = Convert.ToDouble(inputs["TiltY"]);
            double CpuBattery = Convert.ToDouble(inputs["CpuBattery"]);
            double MainBattery = Convert.ToDouble(inputs["MainBattery"]);

            string output = $"Q:00:{DateTime.UtcNow:yyyy/MM/dd HH:mm}\t{Vn:0.000}\t{Ve:0.000}\t{CompassX:0.000}\t{CompassY:0.000}\t{SeaTemp:0.000}\t{Depth:0.000}\t{TiltX:0.000}\t{TiltY:0.000}\t{CpuBattery:0.000}\t{MainBattery:0.000}\r\n";
           
            return output;
        } //Runcode end

        //Private methods start


        //Private methods end
    }
}