using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class VPF730 // Period range: 1000, 2000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            string SensorID = inputs["SensorID"];
            int Visibility = Convert.ToInt32(inputs["Visibility"]);
            double Precipitation = Convert.ToDouble(inputs["Precipitation"]);
            double Temperature = Convert.ToDouble(inputs["Temperature"]);
            int WeatherCode = Convert.ToInt32(inputs["WeatherCode"]);
            int VisObstructionCode = Convert.ToInt32(inputs["VisObstructionCode"]);
            int Period = Convert.ToInt32(inputs["Period"]); //in m
            string WindowContamination = inputs["WindowContamination"];
            bool SelfTestFault = Convert.ToBoolean(inputs["SelfTestFault"]);

            string StatusString = "O" + WindowContamination + (SelfTestFault ? "X" : "O");
            Dictionary<int, string> WCStrings = new Dictionary<int, string>
            {
                { 0,  "NP " },
                { 40, "UP " },
                { 51, "DZ-" },
                { 52, "DZ " },
                { 53, "DZ+" },
                { 61, "RA-" },
                { 62, "RA " },
                { 63, "RA+" },
                { 71, "SN-" },
                { 72, "SN " },
                { 73, "SN+" },
                { 89, "GR " }
            };

            Dictionary<int, string> VOCStrings = new Dictionary<int, string>
            {
                { 0, "  " },
                { 4, "HZ" },
                { 30, "FG" }
            };


            string output = $"{SensorID},{Period:0000},0001,{Visibility / 1000.0:000.00} KM,";
            try
            {
                output += $"{WCStrings[WeatherCode]},";
            }
            catch (Exception e)
            {
                output += "X  ,";
            }
            output += $"{VOCStrings[VisObstructionCode]},00.00,{Precipitation:00.0000},{Temperature:0000.0} C, 000,000.00,000.00,+000.00,     0,  0,{StatusString},  0.00\r\n";
            return output;
        } //Runcode end

        //Private methods start
        
        //Private methods end
    }
}