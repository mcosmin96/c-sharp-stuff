using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class FD12P // 60000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            int VisibilityAlarmCode = Convert.ToInt32(inputs["VisibilityAlarmCode"]); // 0, 1, 2
            int HardwareStateCode = Convert.ToInt32(inputs["HardwareStateCode"]); // 0, 1, 2
            bool ChecksumEnabled = Convert.ToBoolean(inputs["ChecksumEnabled"]);

            double Visibility_1MinAvg = Convert.ToDouble(inputs["Visibility_1MinAvg"]); // 0-50000
            double Visibility_10MinAvg = Convert.ToDouble(inputs["Visibility_10MinAvg"]); // 0-50000
            string WeatherCode_NWS = inputs["WeatherCode_NWS"];
            string WeatherCode = inputs["WeatherCode"]; // 0 ... 99
            string WeatherCode_15MinAvg = inputs["WeatherCode_15MinAvg"]; // 0 ... 99
            string WeatherCode_1HourAvg = inputs["WeatherCode_1HourAvg"]; // 0 ... 99
            double Precipitation = Convert.ToDouble(inputs["Precipitation"]);
            double CumulativeWaterSum = Convert.ToDouble(inputs["CumulativeWaterSum"]); // 0 ... 999
            double CumulativeSnowSum = Convert.ToDouble(inputs["CumulativeSnowSum"]); // 0 ... 999

            string output; //<SOH>FD 01<STX>00  6839  7505   L 52 61 61   0.33  12.16    0<ETX><CR><LF>

            output = "\x01";
            output += "FD 01";
            output += "\x02";
            output += $"{VisibilityAlarmCode}{HardwareStateCode} {Visibility_1MinAvg,5:####0} {Visibility_10MinAvg,5:####0} {WeatherCode_NWS,3:##0} {WeatherCode} {WeatherCode_15MinAvg} " +
                $"{WeatherCode_1HourAvg} {Precipitation,6:##0.00} {CumulativeWaterSum,6:##0.00} {CumulativeSnowSum,4:##0}";
            //output += $"{VisibilityAlarmCode}{HardwareStateCode}\x09{Visibility_1MinAvg}\x09{Visibility_10MinAvg}\x09{WeatherCode_NWS}\x09{WeatherCode}\x09{WeatherCode_15MinAvg}\x09" +
            //    $"{WeatherCode_1HourAvg}\x09{Precipitation}\x09{CumulativeWaterSum}\x09{CumulativeSnowSum}";
            output += "\x03\r\n";
            if (ChecksumEnabled)
                output += $"{CharXorToByte(output):X4}";

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