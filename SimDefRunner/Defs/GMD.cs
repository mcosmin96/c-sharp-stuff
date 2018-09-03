using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class GMD // 60000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            string MessageID = inputs["MessageID"];

            double Temperature = Convert.ToDouble(inputs["Temperature"]);
            double Humidity = Convert.ToDouble(inputs["Humidity"]);
            double Dewpoint = Convert.ToDouble(inputs["Dewpoint"]);
            double Pressure = Convert.ToDouble(inputs["Pressure"]);
            double Trend = Convert.ToDouble(inputs["Trend"]);
            string PressureStatus = inputs["PressureStatus"];
            double SupplyVoltage = Convert.ToDouble(inputs["SupplyVoltage"]);
            double BatteryHealth = Convert.ToDouble(inputs["BatteryHealth"]);
            string DummyCeilometerStatus = inputs["DummyCeilometerStatus"];
            string DummyFD12PStatus = inputs["DummyFD12PStatus"];

            string output; //<SOH>FD 01<STX>00  6839  7505   L 52 61 61   0.33  12.16    0<ETX><CR><LF>

            output = "\x01";
            output += MessageID;
            output += "\x02";
            output += $"{Temperature:0.0}\x09{Humidity:0.0}\x09";
            if(Humidity > 100)
                output += $"NaN\x09";
            else
                output += $"{Dewpoint:0.0}\x09";
            output += $"{Pressure:0.0}\x09{Trend:0.0}\x09{PressureStatus:0}\x09{SupplyVoltage:0.0}\x09{BatteryHealth:0.0}\x09{DummyCeilometerStatus}\x09{DummyFD12PStatus}";
            output += "\x03\r\n";
            output += String.Format("{0:X4}", CharXorToByte(output));

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