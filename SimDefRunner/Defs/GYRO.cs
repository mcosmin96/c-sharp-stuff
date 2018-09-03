using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class GYRO // PeriodRange: 1000, 2000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double Heading = Convert.ToDouble(inputs["Heading"]);

            //HCHDT
            const string SentIdentifierHCHDT = "HCHDT";
            const string FirstParamHCHDT = "";
            const string SecondParamHCHDT = "T*07";

            //PASVW
            const string SentIdentifierPASVW = "PASVW";
            const string FirstParamPASVW = "";
            const string SecondParamPASVW = "V*15";

            //IIVHW
            const string SentIdentifierIIVHW = "IIVHW";
            const string FirstParamIIVHW = "321.2";
            const string SecondParamIIVHW = "T";
            const string ThirdParamIIVHW = "";
            const string FourthParamIIVHW = "M";
            const string FifthParamIIVHW = "";
            const string SixthParamIIVHW = "N";
            const string SeventhParamIIVHW = "";
            const string EighthParamIIVHW = "K*79";

            //HEHDT
            //const string SentIdentifierHEHDT = "HEHDT";

            //HEROT
            const string SentIdentifierHEROT = "HEROT";
            const string FirstParamHEROT = "003.6";
            const string SecondParamHEROT = "A*03";

            string output;

            output = $"${SentIdentifierHCHDT},{FirstParamHCHDT},{SecondParamHCHDT},\r\n";
            output += $"${SentIdentifierPASVW},{FirstParamPASVW},{SecondParamPASVW},\r\n";
            output += $"${SentIdentifierIIVHW},{FirstParamIIVHW}{SecondParamIIVHW},{ThirdParamIIVHW},{FourthParamIIVHW}{FifthParamIIVHW},{SixthParamIIVHW},{SeventhParamIIVHW},{EighthParamIIVHW},\r\n";
            output += GetPayload(Heading);
            output += $"${SentIdentifierHEROT},{FirstParamHEROT},{SecondParamHEROT},{SecondParamHEROT}";

            return output;
        } //Runcode end

        //Private methods start

        private string GetPayload(double heading)
        {
            string payload = "HEHDT,";
            payload += $"{heading:000.0}";
            payload += ",T";
            payload += $"*{CharXorToByte(payload):X2}\r\n";
            return payload;
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