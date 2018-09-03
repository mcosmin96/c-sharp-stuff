using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class CBME80 // PeriodRange: 60000, 30000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            const string MISSING_VALUE = @"/////";

            int CloudBase1 = Convert.ToInt32(inputs["CloudBase1"]); // 0-99999
            int CloudBase2 = Convert.ToInt32(inputs["CloudBase2"]); // 0-99999
            int CloudBase3 = Convert.ToInt32(inputs["CloudBase3"]); // 0-99999
            int VerticalVis = Convert.ToInt32(inputs["VerticalVis"]); // 0-99999

            string SensorID = inputs["SensorID"]; //CBM1
            int SensorStatus = Convert.ToInt32(inputs["SensorStatus"]); //0000 (hex)
            string OutputUnit = inputs["OutputUnit"]; // metres / feet
            int MeasuringRange = Convert.ToInt32(inputs["MeasuringRange"]); // 0-99999
            bool CloudBase1Active = Convert.ToBoolean(inputs["CloudBase1Active"]);
            bool CloudBase2Active = Convert.ToBoolean(inputs["CloudBase2Active"]);
            bool CloudBase3Active = Convert.ToBoolean(inputs["CloudBase3Active"]);
            bool VerticalVisActive = Convert.ToBoolean(inputs["VerticalVisActive"]);

            string output;

            output = $"\x02\r\n {SensorID} {SensorStatus:X4}"; // Sensor ID and Status

            output += Append(CloudBase1, CloudBase1Active, OutputUnit);                     // Cloud Base 1
            output += Append(0, false, OutputUnit);                                         // Cloud Base 1 Penetration (not used)
            output += Append(CloudBase2, CloudBase2Active, OutputUnit);                     // Cloud Base 2
            output += Append(0, false, OutputUnit);                                         // Cloud Base 2 Penetration (not used)
            output += Append(CloudBase3, CloudBase3Active, OutputUnit);                     // Cloud Base 3
            output += Append(0, false, OutputUnit);                                         // Cloud Base 3 Penetration (not used)
            output += Append(VerticalVis, VerticalVisActive, OutputUnit);                   // Vertical Visibility
            output += Append(MeasuringRange, true, OutputUnit);                             // Measuring Range

            output += "\r\n" + @"4/8:00260 6/8:01050 0/8:///// 0/8:///// 6/8" + "\r\n\x03"; // just data from a capture as we don't use it

            output += $"{(char) CharXorToByte(output)}"; // checksum

            var fakeSensorString = "\x02\r\n" + GetFakeSensorString(); // fake data
            
            fakeSensorString += $"\x03{(char) CharXorToByte(fakeSensorString)}"; // fake data checksum

            output += fakeSensorString; // append fakedata

            return output;
        } //Runcode end

        //Private methods start

        private string GetFakeSensorString()
        {
            string fakeString = "";
            int rows = 18;
            int entriesPerLine = 20;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int entryIndex = 0; entryIndex < entriesPerLine; entryIndex++)
                {
                    fakeString += "000 ";
                }
                fakeString += "\r\n";
            }

            return fakeString;
        }

        private string Append(int value, bool active, string unit)
        {
            const double METRES2FEET = 3.2808399;
            if (active)
            {
                value = (unit == "feet") ? value : Convert.ToInt32(value / METRES2FEET);
                return $" {value:00000}";
            }
            else
            {
                return @" /////";
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