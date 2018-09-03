using System;
using log4net;
using log4net.Layout;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Config;
using System.IO;
using System.Threading.Tasks;

namespace Log4net
{
    class Program
    {
        static void Main(string[] args)
        {
            //LoggingWithBasicConfiguration();
            LoggingWithXmlConfiguration();
            //LoggingWithCodeConfiguration();
        }

        private static void LoggingWithCodeConfiguration()
        {
            SimpleLayout layout = new SimpleLayout();
            layout.ActivateOptions();

            ConsoleAppender appender = new ConsoleAppender();
            appender.Layout = layout;
            appender.ActivateOptions();

            FileAppender appender2 = new FileAppender();
            appender2.Layout = layout;
            appender2.File = "FileLog2.txt";
            appender2.ActivateOptions();

            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            Logger root = hierarchy.Root;

            root.Level = Level.All;

            BasicConfigurator.Configure(new IAppender[] { appender, appender2 });

            ILog log = LogManager.GetLogger(typeof(Program));

            log.Debug("debug");
            log.Warn("warn");
            log.Error("");
            log.Fatal("fatality");
            log.Info("Hello from log4net!");

            Console.ReadLine();
        }

        private static void LoggingWithXmlConfiguration()
        {
            var solutionDir = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("Log4net"));

            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo($"{solutionDir}log.config")); // ? no parameter given => App.config is the config file

            ILog log = LogManager.GetLogger(typeof(Program));
            
            Task S = new Task(() =>
            {
                Log(log);
            });

            S.Start();
            MultiThreading.Program.Main(new string[0]);

            //log.Debug("debug");
            //log.Warn("warn");
            //log.Error("");
            //log.Fatal("fatality");
            //if(log.IsInfoEnabled) //otherwise itd run but not output
            //    log.Info("Hello from log4net!");

            Console.ReadLine();
        }

        private static void Log(ILog log)
        {
            for (var i = 0; i < 100; i++)
            {
                log.Info("log4-intask");
            }
        }

        private static void LoggingWithBasicConfiguration()
        {
            log4net.Config.BasicConfigurator.Configure();

            var log = log4net.LogManager.GetLogger(typeof(Program));

            log.Debug("debug");
            log.Warn("warn");
            log.Error("");
            log.Fatal("fatality");
            log.Info("Hello from log4net!");

            Console.Read();
        }
    }
}
