using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Threads.Examples.Tasks
{
    public class Blocking
    {
        public void Execute()
        {
            var task = new Task<int>(ExecuteIn);

            task.Start();

            task.Wait();

            Console.WriteLine("Result: " + task.Result);
        }

        private int ExecuteIn()
        {
            Thread.Sleep(3000);
            Random random = new Random();
            return random.Next();
        }
    }
}
