using log4net;
using System;
using System.Threading;

namespace MultiThreading
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solutionDir = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("NinjectAndStuff")) + "NinjectAndStuff\\";

            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo($"{solutionDir}log.config")); // ? no parameter given => App.config is the config file

            ILog log = LogManager.GetLogger(typeof(Program));

            Thread LoopThread = new Thread(Loop);
            var ex = new InterThreadExceptionMessage();
            LoopThread.Start(ex);
            Console.WriteLine(LoopThread.IsAlive);
            for(var i = 0; i < 100; i++)
            {
                log.Info("multi");
            }
            Console.WriteLine("Main End");
            Console.WriteLine(LoopThread.IsAlive);
            Console.Read();
        }

        static void Loop(object ex)
        {
            var solutionDir = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("Log4net"));

            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo($"{solutionDir}log.config")); // ? no parameter given => App.config is the config file

            ILog log = LogManager.GetLogger(typeof(Program));

            InterThreadExceptionMessage e = ex as InterThreadExceptionMessage;
            try
            {
            }
            catch (Exception exception)
            {
                e.Message = exception.Message;
                return;
            }
            for(var i = 0; i < 100; i++)
            {
                log.Info("multi.inthread");
            }
            Console.WriteLine("Loop End");
        }
    }

    public class InterThreadExceptionMessage
    {
        public string Message { get; set; }
    }
}
