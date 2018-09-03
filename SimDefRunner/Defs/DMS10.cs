using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class DMS10 //PeriodRange: 40, 100, 200
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double RollAngle = Convert.ToDouble(inputs["RollAngle"]); //
            double PitchAngle = Convert.ToDouble(inputs["PitchAngle"]); //
            double Heave = Convert.ToDouble(inputs["Heave"]); //
            double AccelerationX = Convert.ToDouble(inputs["AccelerationX"]); //SurgeAcc
            double AccelerationY = Convert.ToDouble(inputs["AccelerationY"]); //SwayAcc
            double AccelerationZ = Convert.ToDouble(inputs["AccelerationZ"]); //VerticalAcc
            bool IsSettled = Convert.ToBoolean(inputs["IsSettled"]);

            return ":888888.88 " +
                $"{AccelerationX:0.0000e+00;-0.0000e+00} " +
                $"{AccelerationY:0.0000e+00;-0.0000e+00} " +
                $"{AccelerationZ:0.0000e+00;-0.0000e+00} " +
                $"{RollAngle*100:0000;-0000} " +
                $"{PitchAngle*100:0000;-0000} " +
                $"{Heave:0.0000e+00;-0.0000e+00} " +
                (IsSettled ? "U" : "u") +
                "\r\n";
        } //Runcode end

        //Private methods start

        //Private methods end
    }
}