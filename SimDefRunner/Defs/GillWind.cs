using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class GillWind
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double WindDirection = Convert.ToDouble(inputs["WindDirection"]);
            double WindSpeed = Convert.ToDouble(inputs["WindSpeed"]);

            string ID = inputs["ID"];
            string Status = inputs["Status"];
            string SpeedUnits = inputs["SpeedUnits"];
            bool InvalidateWindDirection = Convert.ToBoolean(inputs["InvalidateWindDirection"]);
            bool InvalidateWindSpeed = Convert.ToBoolean(inputs["InvalidateWindSpeed"]);

            string output; //<stx>Q,229,002.74,M,00,<ETX>16

            output = "\x02";
            output += $"{ID},";
            if (!InvalidateWindDirection)
                output += $"{WindDirection:000},";
            if (!InvalidateWindSpeed)
                output += $"{WindSpeed:000.00},";
            output += $"{SpeedUnits},";
            output += $"{Status},";
            output += String.Format("\x03{0:X2}\r\n", CharXorToByte(output));

            return output;
        } //Runcode end

        //Private methods start
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