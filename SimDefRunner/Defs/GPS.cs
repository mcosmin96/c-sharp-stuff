using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class GPS // PeriodRange: 1000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double TrueTrack = Convert.ToDouble(inputs["TrueTrack"]);
            double GroundSpeedKnots = Convert.ToDouble(inputs["GroundSpeedKnots"]);
            double LatitudeDeg = Convert.ToDouble(inputs["LatitudeDeg"]);
            double LatitudeMin = Convert.ToDouble(inputs["LatitudeMin"]);
            char LatitudeHem = Convert.ToChar(inputs["LatitudeHem"]);
            double LongitudeDeg = Convert.ToDouble(inputs["LongitudeDeg"]);
            double LongitudeMin = Convert.ToDouble(inputs["LongitudeMin"]);
            char LongitudeHem = Convert.ToChar(inputs["LongitudeHem"]);
            char DataActive = Convert.ToChar(inputs["DataActive"]);
            double MagneticOffset = Convert.ToDouble(inputs["MagneticOffset"]);

            //VTG
            const string SentIdentifierVTG = "GPVTG";
            const string VarTrueTrack = "T";
            const string VarMagneticTrack = "M";
            const string VarGroundSpeedKnots = "N";
            const string VarGroundSpeedKmh = "K";
            //GLL
            const string SentIdentifierGLL = "GPGLL";
            char[] DATAACTIVE = { 'A', 'V' };

            string output;

            var MagneticTrack = (TrueTrack - MagneticOffset) % 360;
            MagneticTrack = (MagneticTrack < 0) ? MagneticTrack + 360 : MagneticTrack;

            string FixTaken = DateTime.UtcNow.ToString("HHmmss");

            output = AppendWithChecksum("GPDTM,W84,,00.0000,N,00.0000,E,,W84");
            output += AppendWithChecksum($"{SentIdentifierGLL},{LatitudeDeg:00}{LatitudeMin:00.0000},{LatitudeHem},{LongitudeDeg:000}{LongitudeMin:00.0000},{LongitudeHem},{FixTaken:000000},{DataActive}");
            output += AppendWithChecksum($"{SentIdentifierVTG},{TrueTrack:000},{VarTrueTrack},{MagneticTrack:000},{VarMagneticTrack},{GroundSpeedKnots:000.0},{VarGroundSpeedKnots},{KtsToKph(GroundSpeedKnots):000},{VarGroundSpeedKmh}");
            output += AppendWithChecksum($"GPZDA,{DateTime.UtcNow:HHmmss},{DateTime.UtcNow:dd},{DateTime.UtcNow:MM},{DateTime.UtcNow:yyyy},00,00");

            return output;
        } //Runcode end

        //Private methods start

        private string AppendWithChecksum(string data)
        {
            return $"${data}*{CharXorToByte(data):X2}\r\n";
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

        private double KtsToKph(double kts)
        {
            return kts / 0.54;
        }

        //Private methods end
    }
}