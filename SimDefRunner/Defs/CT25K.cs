using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimDefRunner.Defs
{
    public class CT25K // PeriodRange: 60000, 30000, 5000, 1000
    {
        public string Run(Dictionary<string, string> inputs)
        { //Runcode start
            int CloudBase1 = Convert.ToInt32(inputs["CloudBase1"]);
            int CloudBase2 = Convert.ToInt32(inputs["CloudBase2"]);
            int CloudBase3 = Convert.ToInt32(inputs["CloudBase3"]);
            int VerticalVis = Convert.ToInt32(inputs["VerticalVis"]);

            string SensorID = inputs["SensorID"]; //A
            UInt32 SensorStatus = Convert.ToUInt32(inputs["SensorStatus"], 16); //00000100, 00FF7000, FF000000
            bool CloudBase1Active = Convert.ToBoolean(inputs["CloudBase1Active"]);
            bool CloudBase2Active = Convert.ToBoolean(inputs["CloudBase2Active"]);
            bool CloudBase3Active = Convert.ToBoolean(inputs["CloudBase3Active"]);
            bool VerticalVisActive = Convert.ToBoolean(inputs["VerticalVisActive"]);


            //status checks
            
            //metres or feet
            UInt32 metresMask = 0x00000100;
            bool unitIsMetres = (SensorStatus & metresMask) != 0;

            //warning check
            UInt32 warningMask = 0x00FF7000;
            bool isWarning = (SensorStatus & warningMask) != 0;

            //alarm check
            UInt32 alarmMask = 0xFF000000;
            bool isAlarm = (SensorStatus & alarmMask) != 0;

            //sensor status
            string sensorStatus = "0";
            if (isWarning)
            {
                sensorStatus = "W";
            }
            if (isAlarm)
            {
                sensorStatus = "A";
            }

            //cloud status
            int cloudStatus = 0;
            if (CloudBase1Active)
            {
                cloudStatus++;
            }
            if (CloudBase2Active)
            {
                cloudStatus++;
            }
            if (CloudBase3Active)
            {
                cloudStatus++;
            }
            if (VerticalVisActive)
            {
                cloudStatus = 4;
            }

            // Example output from regex "\x01([0-9,A-Z]{7})\x02\r\n([0-9,A-Z]{2}) ([0-9]{5}) ([0-9]{5}) ([0-9]{5}) ([0-9,A-Z]{8})\r\n\x03"
            // Group 0 = CTA1210
            // 30 01428 17820 22000 00000000
            //
            // Group 1 = CTA1210     <--- ID, software version
            // Group 2 = 30          <--- Detection status and alarms/warnings
            // Group 3 = 01428       <--- First value (cloud1 or vert vis)
            // Group 4 = 17820       <--- Second value (cloud2)
            // Group 5 = 22000       <--- Third Value (cloud3)
            // Group 6 = 00000000    <--- Loads of status info
            string output;

            output = "\x01" + $"CT{SensorID}2010\x02\r\n{cloudStatus:0}{sensorStatus} "; // Sensor ID and Status
            if (VerticalVisActive)
            {
                output += Append(VerticalVis, VerticalVisActive, unitIsMetres);
                CloudBase2Active = false;
                CloudBase3Active = false;
            }
            else
            {
                output += Append(CloudBase1, CloudBase1Active, unitIsMetres);
            }
            output += Append(CloudBase2, CloudBase2Active, unitIsMetres);
            output += Append(CloudBase3, CloudBase3Active, unitIsMetres);
            output += $"{SensorStatus:X8}\r\n\x03";
            
            return output;
        } //Runcode end

        //Private methods start
        private string Append(int value, bool active, bool isMetres)
        {
            const double METRES2FEET = 3.2808399;
            if (active)
            {
                value = (!isMetres) ? value : Convert.ToInt32(value / METRES2FEET);
                return $"{value:00000} ";
            }
            else
            {
                return @"///// ";
            }
        }
        //Private methods end
    }
}