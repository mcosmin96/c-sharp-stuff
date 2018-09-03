using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesHandlersLambdas
{

    class Program
    {
        static void Main(string[] args)
        {
            //////WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //////WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //////DoWork(del2 + del1); //adding order = calling order

            ////var worker = new Worker();
            ////worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker_WorkPerformed);
            ////worker.WorkCompleted += new EventHandler(worker_WorkCompleted);
            ////worker.DoWork(8, WorkType.WriteReport);

            //var worker = new Worker();
            //worker.WorkPerformed += Worker_WorkPerformed;
            //worker.WorkCompleted += Worker_WorkCompleted;
            //worker.WorkPerformed -= Worker_WorkPerformed;
            //worker.DoWork(8, WorkType.Code);

            var worker = new Worker();
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine($"{e.Hours} hours");
            };
            worker.WorkCompleted += (s, e) => Console.WriteLine("Work is completed");
            worker.DoWork(5, WorkType.Design);



            Console.Read();
        }

        //private static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker done");
        //}

        //private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine(e.Hours + " " + e.WorkType);
        //}


        ////private static void worker_WorkCompleted(object sender, EventArgs e)
        ////{
        ////    Console.WriteLine("Worker is done!");
        ////}

        ////private static void worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        ////{
        ////    Console.WriteLine(e.Hours + " " + e.WorkType);
        ////}


        //////private static void DoWork(WorkPerformedHandler del)
        //////{
        //////    del(5, WorkType.Design);
        //////}

        //////private static void WorkPerformed2(int hours, WorkType workType)
        //////{
        //////    Console.WriteLine($"Work performed 2 called with {hours} hours");
        //////}

        //////private static void WorkPerformed1(int hours, WorkType workType)
        //////{
        //////    Console.WriteLine($"Work performed 1 called with {hours} hours");
        //////}
    }

    public enum WorkType
    {
        Design,
        Code,
        WriteReport
    }
}
