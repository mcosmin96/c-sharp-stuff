using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimDefRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunGillWind();
            //RunCT25K();
            //RunDMS10();
            //RunElevationOffset();
            RunGPS();
            //RunGyro();
            //RunHygroFlex();
            //RunMTECH8200CHS();
            //RunNortek();
            //RunPTB330();
            //RunPTB220();
            //RunPTU300();
            //RunPWS100();
            //RunRMYOUNG61302V();
            //RunS4ADWI();
            //RunSWS200();
            //RunValeportMiniCT();
            //RunVPF730();
            //RunMetPakRG();
            //RunFD12P();
            //RunGMD();
            Console.Read();
        }

        private static void RunGMD()
        {
            var inputs = new Dictionary<string, string>
            {
                { "MessageID", "GMD180220" },
                { "Temperature", "23" },
                { "Humidity", "142.1" },
                { "Dewpoint", "9.4" },
                { "Pressure", "1011.2" },
                { "Trend", "10.2" },
                { "PressureStatus", "00" },
                { "SupplyVoltage", "4.9" },
                { "BatteryHealth", "87" },
                { "DummyCeilometerStatus", "00000000" },
                { "DummyFD12PStatus", "00" }
            };
            var GMD = new Defs.GMD();
            Console.WriteLine("GMD output:");
            Console.WriteLine(GMD.Run(inputs));
        }

        private static void RunFD12P()
        {
            var inputs = new Dictionary<string, string>
            {
                { "VisibilityAlarmCode", "0" },
                { "HardwareStateCode", "0" },
                { "Visibility_1MinAvg", "6839" },
                { "Visibility_10MinAvg", "7505" },
                { "WeatherCode_NWS", "L" },
                { "WeatherCode", "52" },
                { "WeatherCode_15MinAvg", "61" },
                { "WeatherCode_1HourAvg", "61" },
                { "Precipitation", "0.33" },
                { "CumulativeWaterSum", "12.16" },
                { "CumulativeSnowSum", "0" },
                { "ChecksumEnabled", "true" }
            };
            var FD12P = new Defs.FD12P();
            Console.WriteLine("FD12P output:");
            Console.WriteLine(FD12P.Run(inputs));
        }

        private static void RunMetPakRG()
        {
            var inputs = new Dictionary<string, string>
            {
                { "NodeLetter", "Q" },
                { "WindDirection", "14" },
                { "WindSpeed", "0.06" },
                { "Pressure", "1011.2" },
                { "Humidity", "42.1" },
                { "Temperature", "23" },
                { "Dewpoint", "9.4" },
                { "DigitalInput1", "0" },
                { "SupplyVoltage", "4.9" },
                { "StatusCode", "00" }
            };
            var inputs2 = new Dictionary<string, string>
            {
                { "NodeLetter", "Q" },
                { "WindDirection", "262" },
                { "WindSpeed", "0.04" },
                { "Pressure", "1024.3" },
                { "Humidity", "51.6" },
                { "Temperature", "23.5" },
                { "Dewpoint", "12.9" },
                { "DigitalInput1", "0" },
                { "SupplyVoltage", "4.8" },
                { "StatusCode", "00" }
            };
            var MetPakRG = new Defs.MetPakRG();
            Console.WriteLine("MetPakRG output:");
            Console.WriteLine(MetPakRG.Run(inputs));
            Console.WriteLine(MetPakRG.Run(inputs2));
        }

        private static void RunVPF730()
        {
            var inputs = new Dictionary<string, string>
            {
                { "SensorID", "PW01" },
                { "Period", "60" },
                { "Visibility", "3378" },
                { "WeatherCode", "62" },
                { "VisObstructionCode", "04" },
                { "Precipitation", "0" },
                { "Temperature", "2" },
                { "WindowContamination", "F" },
                { "SelfTestFault", "true" }
            };
            var VPF730 = new Defs.VPF730();
            Console.WriteLine("VPF730 output:");
            Console.WriteLine(VPF730.Run(inputs));
        }

        private static void RunValeportMiniCT()
        {
            var inputs = new Dictionary<string, string>
            {
                { "Visibility", "3378" },
                { "Precipitation", "1.2" },
                { "Status", "1" },
                { "WeatherCode", "52" },
                { "CS215Present", "true" },
                { "DryTemperature", "2" },
                { "Humidity", "94" },
                { "WetTemperature", "-1" }
            };
            var PWS100 = new Defs.PWS100();
            Console.WriteLine("PWS100 output:");
            Console.WriteLine(PWS100.Run(inputs));
        }

        private static void RunSWS200()
        {
            var inputs = new Dictionary<string, string>
            {
                { "AveragingTimePeriod", "60" },
                { "AverageVisibility", "20" },
                { "Precipitation", "0" },
                { "WeatherCode", "XX" },
                { "Temperature", "99.9" },
                { "Visibility", "20" },
                { "RMFault", "false" },
                { "WindowContaminated", "false" },
                { "SensorNotReset", "false" }

            };
            var SWS200 = new Defs.SWS200();
            Console.WriteLine("SWS200 output:");
            Console.WriteLine(SWS200.Run(inputs));
        }

        private static void RunS4ADWI()
        {
            var inputs = new Dictionary<string, string>
            {
                { "StartTime", DateTime.UtcNow.ToString() },
                { "QPeriod", "10" },
                { "Vn", "-3.97" },
                { "Ve", "-0.78" },
                { "CompassX", "0.19" },
                { "CompassY", "0.19" },
                { "SeaTemp", "25.681" },
                { "Depth", "0.278" },
                { "TiltX", "0" },
                { "TiltY", "0" },
                { "CpuBattery", "5.0" },
                { "MainBattery", "12.2" },

                { "SPeriod", "10" },
                { "MWD", "0.28" },
                { "Hav", "0" },
                { "Hs", "0" },
                { "Hmax", "0.01" },
                { "H110", "0.01" },
                { "Tp", "9.5" },
                { "Tz", "5.2" },
                { "Ts", "5.3" },
                { "Tc", "4.0" },
                { "Tmax", "5.5" },
                { "DIR", "274" },
                { "STD", "0" },
                { "EPS", "0.65" },
                { "AUTOCUTOFF", "0.333" }
            };
            var S4ADWI = new Defs.S4ADWI_Combined();
            Console.WriteLine("S4ADWI output:");
            Console.WriteLine(S4ADWI.Run(inputs));
        }

        private static void RunRMYOUNG61302V()
        {
            var inputs = new Dictionary<string, string>
            {

                { "Pressure", "25.980" }
            };
            var RMYOUNG61302V = new Defs.RMYOUNG61302V();
            Console.WriteLine("RMYOUNG61302V output:");
            Console.WriteLine(RMYOUNG61302V.Run(inputs));
        }

        private static void RunPWS100()
        {
            var inputs = new Dictionary<string, string>
            {
                { "Visibility", "3378" },
                { "Precipitation", "1.2" },
                { "Status", "1" },
                { "WeatherCode", "52" },
                { "CS215Present", "true" },
                { "DryTemperature", "2" },
                { "Humidity", "94" },
                { "WetTemperature", "-1" }
            };
            var PWS100 = new Defs.PWS100();
            Console.WriteLine("PWS100 output:");
            Console.WriteLine(PWS100.Run(inputs));
        }

        private static void RunPTU300()
        {
            var inputs = new Dictionary<string, string>
            {
                { "Cell1", "987.61" },
                { "Cell2", "987.61" },
                { "Temperature", "7.61" },
                { "Humidity", "80" },
                { "PressureFault", "false" },
                { "TemperatureAFault", "false" },
                { "TemperatureFault", "false" },
                { "HumidityFault", "false" },
                { "OutputFormat", "Miros.NO" }
            };
            var PTU300 = new Defs.PTU300();
            Console.WriteLine("PTU300 output:");
            Console.WriteLine(PTU300.Run(inputs));
        }

        private static void RunPTB220()
        {
            var inputs = new Dictionary<string, string>
            {
                { "PressCell1", "987.61" },
                { "PressCell2", "987.61" },
                { "PressCell3", "987.61" },
                { "InvalidatePressCell1", "true" },
                { "InvalidatePressCell2", "true" },
                { "InvalidatePressCell3", "true" },
            };
            var PTB220 = new Defs.PTB220();
            Console.WriteLine("PTB220 output:");
            Console.WriteLine(PTB220.Run(inputs));
        }

        private static void RunPTB330()
        {
            var inputs = new Dictionary<string, string>
            {
                { "PressCell1", "987.61" },
                { "PressCell2", "987.61" },
                { "InvalidatePressCell1", "true" },
                { "InvalidatePressCell2", "false" },
            };
            var PTB330 = new Defs.PTB330();
            Console.WriteLine("PTB330 output:");
            Console.WriteLine(PTB330.Run(inputs));
        }

        private static void RunNortek()
        {
            var inputs = new Dictionary<string, string>
            {
            };
            var Nortek = new Defs.Nortek();
            Console.WriteLine("Nortek output:");
            Console.WriteLine(Nortek.Run(inputs));
        }

        private static void RunMTECH8200CHS()
        {
            var inputs = new Dictionary<string, string>
            {
                { "CloudBase1", "1000" },
                { "CloudBase2", "3000" },
                { "VerticalVis", "2000" },
                { "SkyCondition", "TwoCloud" },
                { "HardwareAlarm", "true" },
                { "VoltageAlarm", "false" },
                { "LaserAlarm", "false" },
                { "TempAlarm", "true" },
                { "SolarDetected", "false" },
                { "BlowerOn", "false" },
                { "HeaterOn", "false" },
                { "UnitsFt", "true" },
            };
            var MTECH8200CHS = new Defs.MTECH8200CHS();
            Console.WriteLine("MTECH8200CHS output:");
            Console.WriteLine(MTECH8200CHS.Run(inputs));
        }

        private static void RunHygroFlex()
        {
            var inputs = new Dictionary<string, string>
            {
                { "Pressure", "986.32" },
                { "Humidity", "30.590" },
                { "Temperature", "20.470" },
                { "TempHumidityProbeConnected", "false" },
                { "PressureProbeConnected", "false" },
            };
            var HygroFlex = new Defs.HygroFlex();
            Console.WriteLine("HygroFlex output:");
            Console.WriteLine(HygroFlex.Run(inputs));
        }

        private static void RunGyro()
        {
            var inputs = new Dictionary<string, string>
            {

                { "Heading", "2.0" }
            };
            var GYRO = new Defs.GYRO();
            Console.WriteLine("GYRO output:");
            Console.WriteLine(GYRO.Run(inputs));
        }

        private static void RunGPS()
        {
            var inputs = new Dictionary<string, string>
            {
                { "TrueTrack", "054.7" },
                { "GroundSpeedKnots", "005.5" },
                { "LatitudeDeg", "49" },
                { "LatitudeMin", "16.4556" },
                { "LatitudeHem", "N" },
                { "LongitudeDeg", "123" },
                { "LongitudeMin", "11.1256" },
                { "LongitudeHem", "W" },
                { "DataActive", "A" },
                { "MagneticOffset", "18" }
            };
            var GPS = new Defs.GPS();
            Console.WriteLine("GPS output:");
            Console.WriteLine(GPS.Run(inputs));
        }

        private static void RunElevationOffset()
        {
            var inputs = new Dictionary<string, string>
            {

                { "ElevationOffset", "25.980" }
            };
            var ElevationOffset = new Defs.ElevationOffset();
            Console.WriteLine("ElevationOffset output:");
            Console.WriteLine(ElevationOffset.Run(inputs));
        }

        private static void RunDMS10()
        {
            var inputs = new Dictionary<string, string>
            {

                { "RollAngle", "-1.69" },
                { "PitchAngle", "-1.64" },
                { "Heave", "-1.55" },
                { "AccelerationX", "-9.010024" },
                { "AccelerationY", "-0.000350" },
                { "AccelerationZ", "-0.123456" },
                { "IsSettled", "false" }
            };
            var DMS10 = new Defs.DMS10();
            Console.WriteLine("DMS10 output:");
            Console.WriteLine(DMS10.Run(inputs));
        }

        private static void RunCT25K()
        {
            var inputs = new Dictionary<string, string>
            {

                { "CloudBase1", "1000" },
                { "CloudBase2", "3000" },
                { "CloudBase3", "9000" },
                { "VerticalVis", "2000" },
                { "SensorID", "A" },
                { "SensorStatus", "FF000000" },
                { "CloudBase1Active", "true" },
                { "CloudBase2Active", "true" },
                { "CloudBase3Active", "true" },
                { "VerticalVisActive", "false" }

            };
            var CT25K = new Defs.CT25K();
            Console.WriteLine("CT25K output:");
            Console.WriteLine(CT25K.Run(inputs));
        }

        private static void RunCBME80()
        {
            var inputs = new Dictionary<string, string>
            {

                { "CloudBase1", "1000" },
                { "CloudBase2", "3000" },
                { "CloudBase3", "9000" },
                { "VerticalVis", "2000" },
                { "SensorID", "CBM1" },
                { "SensorStatus", "0" },
                { "OutputUnit", "feet" },
                { "MeasuringRange", "25000" },
                { "CloudBase1Active", "true" },
                { "CloudBase2Active", "true" },
                { "CloudBase3Active", "true" },
                { "VerticalVisActive", "true" }

            };
            var CBME80 = new Defs.CBME80();
            Console.WriteLine("CBME80 output:");
            Console.WriteLine(CBME80.Run(inputs));
        }

        private static void RunGillWind()
        {
            var inputs = new Dictionary<string, string>
            {

                { "WindDirection", "180" },
                { "WindSpeed", "62" },
                { "ID", "B" },
                { "Status", "00" },
                { "SpeedUnits", "P" },
                { "InvalidateWindDirection", "false" },
                { "InvalidateWindSpeed", "false" }

            };
            var GillWind = new Defs.GillWind();
            Console.WriteLine("GillWind output:");
            Console.WriteLine(GillWind.Run(inputs));
        }
    }
}
