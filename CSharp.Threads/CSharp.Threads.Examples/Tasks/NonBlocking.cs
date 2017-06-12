using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Threads.Examples.Tasks
{
    public class NonBlocking
    {
        public void ExecuteNonBlocking()
        {
            Task<int> task = new Task<int>(Insert);

            task.ContinueWith(
                t => Console.WriteLine("Result: " + t.Result),
                TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(
                t => Console.WriteLine("Fault: " + t.Exception),
                TaskContinuationOptions.OnlyOnFaulted);

            task.ContinueWith(
                t => Console.WriteLine("Canceled"),
                TaskContinuationOptions.OnlyOnCanceled);

            task.Start();
        }

        private int Insert()
        {
            Thread.Sleep(3000);
            Random random = new Random();
            return random.Next();
        }
    }
}
