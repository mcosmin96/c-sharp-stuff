using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class MTECH8200CHS // Period range: 60000, 30000, 15000, 5000, 1000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            int CloudBase1 = Convert.ToInt32(inputs["CloudBase1"]);
            int CloudBase2 = Convert.ToInt32(inputs["CloudBase2"]);
            int VerticalVis = Convert.ToInt32(inputs["VerticalVis"]);
            string SkyCondition = inputs["SkyCondition"];
            bool HardwareAlarm = Convert.ToBoolean(inputs["HardwareAlarm"]);
            bool VoltageAlarm = Convert.ToBoolean(inputs["VoltageAlarm"]);
            bool LaserAlarm = Convert.ToBoolean(inputs["LaserAlarm"]);
            bool TempAlarm = Convert.ToBoolean(inputs["TempAlarm"]);
            bool SolarDetected = Convert.ToBoolean(inputs["SolarDetected"]);
            bool BlowerOn = Convert.ToBoolean(inputs["BlowerOn"]);
            bool HeaterOn = Convert.ToBoolean(inputs["HeaterOn"]);
            bool UnitsFt = Convert.ToBoolean(inputs["UnitsFt"]);

            const string MISSINGVALUE = @"/////";
            const string PADDING = @"00000";

        string alarm = (HardwareAlarm ? "1" : "0")
                + (VoltageAlarm ? "1" : "0")
                + (LaserAlarm ? "1" : "0")
                + (TempAlarm ? "1" : "0")
                + (SolarDetected ? "1" : "0")
                + (BlowerOn ? "1" : "0")
                + (HeaterOn ? "1" : "0")
                + (UnitsFt ? "1" : "0")
                + "00";

            int SkyCase = 0;
            switch (SkyCondition)
            {
                case "NoCloud":
                    SkyCase = 0;
                    break;
                case "OneCloud":
                    SkyCase = 1;
                    break;
                case "TwoCloud":
                    SkyCase = 2;
                    break;
                case "VerticalVis":
                    SkyCase = 3;
                    break;
                case "SkyObscured":
                    SkyCase = 4;
                    break;
            }

            string output = $"\x02\r\n{SkyCase}0  " +
                (SkyCase == 3 ? VerticalVis.ToString(PADDING) : (SkyCase == 1 || SkyCase == 2 ? CloudBase1.ToString(PADDING) : MISSINGVALUE)) + " " +
                (SkyCase == 3 ? VerticalVis.ToString(PADDING) : (SkyCase == 1 || SkyCase == 2 ? CloudBase1.ToString(PADDING) : MISSINGVALUE)) + " " +
                (SkyCase == 2 ? CloudBase2.ToString(PADDING) : MISSINGVALUE) + " " +
                (SkyCase == 2 ? CloudBase2.ToString(PADDING) : MISSINGVALUE) + " " +
                $"{alarm}\r\n  6  06  8  11  0   0  0   0\r\n\x03\r\n";

            return output;
        } //Runcode end

        //Private methods start

        //Private methods end
    }
}