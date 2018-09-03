using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimDefRunner.Defs
{
    public class MetPakRG // PeriodRange: 1000, 2000, 4000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            char NodeLetter = Convert.ToChar(inputs["NodeLetter"]);
            int WindDirection = Convert.ToInt32(inputs["WindDirection"]);
            double WindSpeed = Convert.ToDouble(inputs["WindSpeed"]);
            double Pressure = Convert.ToDouble(inputs["Pressure"]);
            double Humidity = Convert.ToDouble(inputs["Humidity"]);
            double Temperature = Convert.ToDouble(inputs["Temperature"]);
            double Dewpoint = Convert.ToDouble(inputs["Dewpoint"]);
            double DigitalInput1 = Convert.ToDouble(inputs["DigitalInput1"]);
            double SupplyVoltage = Convert.ToDouble(inputs["SupplyVoltage"]);
            string StatusCode = inputs["StatusCode"];

            string output; //<STX>Q,014,000.06,1011.2,042.1,+023.0,+009.4,0000.000,+04.9,00,<ETX>40 & (CR,LF)

            output = $"{NodeLetter},{WindDirection:000},{WindSpeed:000.00},{Pressure:0000.0},{Humidity:000.0},{Temperature:+000.0;-000.0},{Dewpoint:+000.0;-000.0},{DigitalInput1:0000.000},{SupplyVoltage:+00.0;-00.0},{StatusCode},";

            output = $"\x02{output}\x03{CharXorToByte(output):X2}\r\n";
            return output;
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
    }
}
