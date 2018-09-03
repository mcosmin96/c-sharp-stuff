using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class PTU300 // Period range: 1000, 2000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double Cell1 = Convert.ToDouble(inputs["Cell1"]);
            double Cell2 = Convert.ToDouble(inputs["Cell2"]);
            double Temperature = Convert.ToDouble(inputs["Temperature"]);
            double Humidity = Convert.ToDouble(inputs["Humidity"]);
            bool PressureFault = Convert.ToBoolean(inputs["PressureFault"]);
            bool TemperatureAFault = Convert.ToBoolean(inputs["TemperatureAFault"]);
            bool TemperatureFault = Convert.ToBoolean(inputs["TemperatureFault"]);
            bool HumidityFault = Convert.ToBoolean(inputs["HumidityFault"]);
            string OutputFormat = inputs["OutputFormat"];

            double diff = Math.Abs(Cell1 - Cell2);
            bool sendPressureFault = diff > 0.5;

            string faultString = PressureFault | sendPressureFault ? "1" : "0";
            faultString += TemperatureFault ? "1" : "0";
            faultString += TemperatureAFault ? "1" : "0";
            faultString += HumidityFault ? "1" : "0";
            string output = "";
            switch (OutputFormat)
            {
                case "Miros.UK":
                    output = $"\x01{Cell1:0000.00}, HPa, {Cell2:0000.00}, HPa, {(sendPressureFault ? "******" : $"{((Cell1 + Cell2) / 2):0000.00}")}, HPa, {Temperature:00.00},  0C,{Humidity:00.00}, %RH, {faultString}\r\n\x05";
                    break;
                case "Miros.NO":
                    output = $"* {Cell1:0000.00} {Cell2:0000.00} {(sendPressureFault ? "******" : $"{((Cell1 + Cell2) / 2):0000.00}")} hPa {Temperature,5:#0.00} 'C {Humidity:00.0} %RH\r\n";
                    break;
            }

            return output;
        } //Runcode end

        //Private methods start

        //Private methods end
    }
}