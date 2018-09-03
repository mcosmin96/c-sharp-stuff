using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class Nortek // PeriodRange: 1000, 2000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            PNORIstruct PNORI = new PNORIstruct();
            PNORSstruct PNORS = new PNORSstruct();
            PNORS.ErrorCode = "00";
            PNORWstruct PNORW = new PNORWstruct();
            PNORW.ErrorCode = "00";

            string output;

            output = AppendWithChecksum($"PNORI,{PNORI.InstrumentType},{PNORI.HeadID},{PNORI.NumberOfBeams},{PNORI.NumberOfCells},{PNORI.Blanking}," +
                $"{PNORI.CellSize},{PNORI.CoordinateSystem}");
            output += AppendWithChecksum($"PNORS,{DateTime.UtcNow.ToString("MMddyy")},{DateTime.UtcNow.ToString("HHmmss")},{PNORS.ErrorCode}," +
                $"{PNORS.StatusCode},{PNORS.BatteryVoltage},{PNORS.SoundSpeed},{PNORS.Heading},{PNORS.Pitch},{PNORS.Roll},{PNORS.Pressure}," +
                $"{PNORS.Temperature},{PNORS.Analog1},{PNORS.Analog2}");
            output += AppendWithChecksum($"PNORW,{DateTime.UtcNow.ToString("MMddyy")},{DateTime.UtcNow.ToString("HHmmss")},{PNORW.SpectrumBasis}," +
                $"{PNORW.ProcessingMethod},{PNORW.Hm0},{PNORW.H3},{PNORW.H10},{PNORW.HMax},{PNORW.Tm02},{PNORW.Tp},{PNORW.Tz},{PNORW.DirTp},{PNORW.SprTp}," +
                $"{PNORW.MainDirection},{PNORW.Unidirectivity},{PNORW.MeanPressure},{PNORW.NumbearOfNoDetects},{PNORW.NumberOfBadDetects},{PNORW.CurrentSpeed}," +
                $"{PNORW.CurrentDirection},{PNORW.ErrorCode}");

            return output;
        } //Runcode end

        //Private methods start
        public struct PNORIstruct
        {
            public int InstrumentType;
            public string HeadID;
            public int NumberOfBeams;
            public int NumberOfCells;
            public double Blanking;
            public double CellSize;
            public int CoordinateSystem;
        }

        public struct PNORSstruct
        {
            public string ErrorCode;
            public string StatusCode;
            public double BatteryVoltage;
            public double SoundSpeed;
            public double Heading;
            public double Pitch;
            public double Roll;
            public double Pressure;
            public double Temperature;
            public int Analog1;
            public int Analog2;
        }

        public struct PNORWstruct
        {
            public string ErrorCode;
            public double CurrentDirection;
            public double CurrentSpeed;
            public int NumberOfBadDetects;
            public int NumbearOfNoDetects;
            public double MeanPressure;
            public double Unidirectivity;
            public double MainDirection;
            public double SprTp;
            public double DirTp;
            public double Tz;
            public double Tp;
            public double Tm02;
            public double HMax;
            public double H10;
            public double H3;
            public double Hm0;
            public int ProcessingMethod;
            public int SpectrumBasis;
        }

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

        //Private methods end
    }
}