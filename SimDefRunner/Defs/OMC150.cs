using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class OMC150
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            int WindDirection = Convert.ToInt32(inputs["WindDirection"]);
            float WindSpeed = (float)Convert.ToDouble(inputs["WindSpeed"]);

            string MessageFormat = inputs["MessageFormat"];
            string NMEASentence = inputs["NMEASentence"];

            Dictionary<string, Func<int, float, string>> Formatters =
                new Dictionary<string, Func<int, float, string>>()
                {
                    {
                        "Obsermet",
                        (windDirection, windSpeed) => FormatObsermet(windDirection, windSpeed)
                    },
                    {
                        "NMEA$WIMWV",
                        (windDirection, windSpeed) => FormatNMEAWIMWV(windDirection, windSpeed)
                    },
                    {
                        "NMEA$IIMWV",
                        (windDirection, windSpeed) => FormatNMEAIIMWV(windDirection, windSpeed)
                    }
                };

            return Formatters[MessageFormat + NMEASentence].Invoke(WindDirection, WindSpeed);
        } //Runcode end

        //Private methods start
        private string FormatObsermet(int windDirection, float windSpeed)
        {
            string output;
            output = $"\nD{windDirection:000} V{windSpeed * 10:000} ";
            output += $"{Bytesum(output):X2}\r";
            return output;
        }

        private string FormatNMEAWIMWV(int windDirection, float windSpeed)
        {
            string output = $"WIMWV,{windDirection:000},T,V{windSpeed:000},N,A";
            return $"${output}*{CharXorToByte(output):X2}\r\n";
        }

        private string FormatNMEAIIMWV(int windDirection, float windSpeed)
        {
            string output;
            output = "IIMWV,";
            if (windSpeed >= 0.05)
                output += $"{windDirection:000}";
            output += $",R,{windSpeed:000.00},M,A";
            return $"${output}*{CharXorToByte(output):X2}\r\n";
        }

        private byte Bytesum(string data)
        {
            try
            {
                uint total = 0x0d;
                byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(data.ToCharArray());
                for (int i = 0; i < bytes.Length; i++)
                {
                    total += bytes[i];
                }

                return (byte)(total % 256);
            }
            catch
            {
                return 0;
            }
        }

        private byte CharXorToByte(string data)
        {
            try
            {
                byte crc = 0;
                byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(data.ToCharArray());
                for (short index = 0; index < bytes.Count(); index++)
                {
                    crc = (byte)(crc ^ bytes[index]);
                }

                return crc;
            }
            catch
            {
                return 0;
            }
        }
        //Private methods end
    }
}