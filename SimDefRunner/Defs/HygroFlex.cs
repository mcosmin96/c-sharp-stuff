using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class HygroFlex // Period range: 1000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double Pressure = Convert.ToDouble(inputs["Pressure"]);
            double Humidity = Convert.ToDouble(inputs["Humidity"]);
            double Temperature = Convert.ToDouble(inputs["Temperature"]);
            bool TempHumidityProbeConnected = Convert.ToBoolean(inputs["TempHumidityProbeConnected"]);
            bool PressureProbeConnected = Convert.ToBoolean(inputs["PressureProbeConnected"]);

            string output;

            var HumidityValue = TempHumidityProbeConnected ? $"{Humidity:00.000}" : "--.-- ";
            var TempValue = TempHumidityProbeConnected ? $"{Temperature:00.000}" : "--.-- ";
            var PressureValue = PressureProbeConnected ? $"{Pressure:000.00}" : "--.-- ";

            output = $"{{H00rdd 1;{HumidityValue}; %rh;0;+;{TempValue};  °C;0;=;  ; --.--;    ;0; ;001;V1.8-2;0061070000;Probe 1     ;000;3;{PressureValue}; hPa;000;=;Probe 2     ;5;0;0;Relay 1    ;5;0;0;Relay 2    ;5;0;0;Relay 3    ;5;0;0;Relay 4    ;6;083;V2.1m ;0060582376;HF83        ;000;";
            output += $"{(char)Base64Sum(output)}\r";
            return output;
        } //Runcode end

        //Private methods start
        private byte Base64Sum(string data)
        {
            try
            {
                uint total = 0;
                byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(data.ToCharArray());
                for (int i = 0; i < bytes.Length; i++)
                {
                    total += bytes[i];
                }

                return (byte)(total % 64 + 32);
            }
            catch
            {
                return 32;
            }
        }
        //Private methods end
    }
}