using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class S4ADWI_Combined // PeriodRange: 1000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start

            DateTime StartTime = DateTime.Parse(inputs["StartTime"]);
            //Q
            int QPeriod = Convert.ToInt32(inputs["QPeriod"]);
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

            //S
            int SPeriod = Convert.ToInt32(inputs["SPeriod"]);
            double MWD = Convert.ToDouble(inputs["MWD"]);
            double Hav = Convert.ToDouble(inputs["Hav"]);
            double Hs = Convert.ToDouble(inputs["Hs"]);
            double Hmax = Convert.ToDouble(inputs["Hmax"]);
            double H110 = Convert.ToDouble(inputs["H110"]);
            double Tp = Convert.ToDouble(inputs["Tp"]);
            double Tz = Convert.ToDouble(inputs["Tz"]);
            double Ts = Convert.ToDouble(inputs["Ts"]);
            double Tc = Convert.ToDouble(inputs["Tc"]);
            double Tmax = Convert.ToDouble(inputs["Tmax"]);
            double DIR = Convert.ToDouble(inputs["DIR"]);
            double STD = Convert.ToDouble(inputs["STD"]);
            double EPS = Convert.ToDouble(inputs["EPS"]);
            double AUTOCUTOFF = Convert.ToDouble(inputs["AUTOCUTOFF"]);

            TimeSpan timeSinceStart = DateTime.UtcNow - StartTime;

            bool fireQ = (timeSinceStart.TotalMinutes % QPeriod < 1) ? true : false;
            bool fireS = (timeSinceStart.TotalMinutes % SPeriod < 1) ? true : false;

            string output = "";

            if (fireQ)
            {
                output += $"Q:00:{DateTime.UtcNow:yyyy/MM/dd HH:mm}\t{Vn:0.000}\t{Ve:0.000}\t{CompassX:0.000}\t{CompassY:0.000}\t{SeaTemp:0.000}\t{Depth:0.000}\t{TiltX:0.000}\t{TiltY:0.000}\t{CpuBattery:0.000}\t{MainBattery:0.000}\r\n";
            }
            if (fireS)
            {
                output += $"S:00:{DateTime.UtcNow:yyyy/MM/dd HH:mm}\t{MWD:0.00}\t{Hav:0.00}\t{Hs:0.00}\t{Hmax:0.00}\t{H110:0.00}\t{Tp:0.0}\t{Tz:0.0}\t{Ts:0.0}\t{Tc:0.0}\t{Tmax:0.0}\t{DIR:0}\t{STD:0.00}\t{EPS:0.00}\t{AUTOCUTOFF:0.000}\r\n";
            }

            return output;
        } //Runcode end

        //Private methods start


        //Private methods end
    }
}