using System;
using System.Threading.Tasks;

namespace Asynchronous_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            while (number != 0)
            {
                Console.WriteLine("Enter number: ");
                number = Int32.Parse(Console.ReadLine());
                //ulong result = 0;

                // Task S = new Task(() =>
                // {
                //     result = Simulate(number);
                // });

                // Task Sc = S.ContinueWith((antecedent) =>
                //{
                //    Console.WriteLine($"{number} * {number} = {result}");
                //});

                // S.Start();

                Task<ulong> S = Task.Factory.StartNew(() =>
                {
                    ulong result = Simulate(number);
                    return result;
                });

                //Console.ReadLine(); // Sc wouldnt work until you enter something

                //Task Sc = S.ContinueWith((antecedent) =>
                //{
                //    Console.WriteLine($"{number} * {number} = {result}");
                //});

                //S.Wait(); //waits for S to compute before outputting the result

                //Task.WaitAll(taskArray); // wait on all tasks to finish
                //int index = Task.WaitAny(taskArray); // wait for the first to finish, taskArray[index] is the task that finished

                Console.WriteLine($"{number} * {number} = {S.Result}");
                //when you call S.Result the call only returns when the Task is done computing, obviously


            }
        }

        private static ulong Simulate(int number)
        {
            ulong c = 0;
            for(int i = 0; i < number; i++)
            {
                for(int j = 0; j < number; j++)
                {
                    c++;
                }
            }
            return c;
        }
    }
}
