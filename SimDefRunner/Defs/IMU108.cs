using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class IMU108
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double RollAngle = Convert.ToDouble(inputs["RollAngle"]); //
            double PitchAngle = Convert.ToDouble(inputs["PitchAngle"]); //
            double Yaw = Convert.ToDouble(inputs["Yaw"]);
            double Surge = Convert.ToDouble(inputs["Surge"]);
            double Sway = Convert.ToDouble(inputs["Sway"]);
            double Heave = Convert.ToDouble(inputs["Heave"]); //
            double SurgeVelocity = Convert.ToDouble(inputs["SurgeVelocity"]);
            double SwayVelocity = Convert.ToDouble(inputs["SwayVelocity"]);
            double HeaveVelocity = Convert.ToDouble(inputs["HeaveVelocity"]);
            double AccelerationX = Convert.ToDouble(inputs["AccelerationX"]); //
            double AccelerationY = Convert.ToDouble(inputs["AccelerationY"]); //
            double AccelerationZ = Convert.ToDouble(inputs["AccelerationZ"]); //

            string output = "$PSMCC,"; //$PSMCC,+xx.xx,+yy.yy,+zzz.z,+ss.ss,+ww.ww,+hh.hh,+sv.sv,+sw.sw,+hv.hv,+ax.axa,+ay.aya,+az.aza*cs
            output += $"{RollAngle:+00.00;-00.00},";
            output += $"{PitchAngle:+00.00;-00.00},";
            output += $"{Yaw:+000.0;-000.0},";
            output += $"{Surge:+00.00;-00.00},";
            output += $"{Sway:+00.00;-00.00},";
            output += $"{Heave:+00.00;-00.00},";
            output += $"{SurgeVelocity:+00.00;-00.00},";
            output += $"{SwayVelocity:+00.00;-00.00},";
            output += $"{HeaveVelocity:+00.00;-00.00},";
            output += $"{AccelerationX:+00.000;-00.000},";
            output += $"{AccelerationY:+00.000;-00.000},";
            output += $"{AccelerationZ:+00.000;-00.000}";
            output += $"*{CharXorToByte(output):X2}\r\n";

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