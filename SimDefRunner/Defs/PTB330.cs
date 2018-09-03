using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class PTB330 // Period range: 1000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            double PressCell1 = Convert.ToDouble(inputs["PressCell1"]);
            double PressCell2 = Convert.ToDouble(inputs["PressCell2"]);
            //double PressCell3 = Convert.ToDouble(inputs["PressCell3"]);
            bool InvalidatePressCell1 = Convert.ToBoolean(inputs["InvalidatePressCell1"]);
            bool InvalidatePressCell2 = Convert.ToBoolean(inputs["InvalidatePressCell2"]);
            //bool InvalidatePressCell3 = Convert.ToBoolean(inputs["InvalidatePressCell3"]);

            double pressure = 0;
            int validCells = 0;
            double minPress = 1101.0;
            double maxPress = 499.0;
            string errorCode = "";

            string formattedCell1 = "***.**";
            if (!InvalidatePressCell1)
            {
                pressure += PressCell1;
                validCells++;
                formattedCell1 = $"{PressCell1:000.00}";
                minPress = PressCell1 < minPress ? PressCell1 : minPress;
                maxPress = PressCell1 > maxPress ? PressCell1 : maxPress;
                errorCode += "0";
            }
            else
            {
                errorCode += "1";
            }

            string formattedCell2 = "***.**";
            if (!InvalidatePressCell2)
            {
                pressure += PressCell2;
                validCells++;
                formattedCell2 = $"{PressCell2:000.00}";
                minPress = PressCell2 < minPress ? PressCell2 : minPress;
                maxPress = PressCell2 > maxPress ? PressCell2 : maxPress;
                errorCode += "0";
            }
            else
            {
                errorCode += "1";
            }

            string formattedPressure = "***.**";
            if ((validCells >= 2) && ((maxPress - minPress) < 0.5))
            {
                formattedPressure = $"{(pressure / validCells):000.00}";
            }


            string output = $" {formattedCell1.PadLeft(7)}  {formattedCell2.PadLeft(7)}  {formattedPressure.PadLeft(7)} hPa {errorCode}\r\n ";

            return output;
        } //Runcode end

        //Private methods start
        
        //Private methods end
    }
}