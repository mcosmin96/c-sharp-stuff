using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class SWS200 // Period range: 15000, 60000, 120000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            int AveragingTimePeriod = Convert.ToInt32(inputs["AveragingTimePeriod"]);
            double AverageVisibility = Convert.ToDouble(inputs["AverageVisibility"]);
            double Precipitation = Convert.ToDouble(inputs["Precipitation"]);
            string WeatherCode = inputs["WeatherCode"];
            double Temperature = Convert.ToDouble(inputs["Temperature"]);
            double Visibility = Convert.ToDouble(inputs["Visibility"]);
            bool RMFault = Convert.ToBoolean(inputs["RMFault"]);
            bool WindowContaminated = Convert.ToBoolean(inputs["WindowContaminated"]);
            bool SensorNotReset = Convert.ToBoolean(inputs["SensorNotReset"]);

            string RMFaultString = RMFault ? "X" : "O";
            string WindowContaminatedString = WindowContaminated ? "X" : "O";
            string SensorNotResetString = SensorNotReset ? "X" : "O";

            string output = $"SWS200,001,{AveragingTimePeriod:000},{AverageVisibility:00.00} KM,{Precipitation:00.000},{WeatherCode},{Temperature:+00.0;-00.0} C,{Visibility:00.00} KM,{RMFaultString}{WindowContaminatedString}{SensorNotResetString}\r\n";
            return output;
        } //Runcode end

        //Private methods start
        
        //Private methods end
    }
}