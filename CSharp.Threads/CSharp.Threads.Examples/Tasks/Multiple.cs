using System;
using System.Threading.Tasks;

namespace CSharp.Threads.Examples.Tasks
{
    public class Multiple
    {
        public void Execute()
        {
            var parent = new Task<int[]>(() =>
            {
                var results = new int[2];

                new Task(() => results[0] = Sum(10000),
                    TaskCreationOptions.AttachedToParent).Start();

                new Task(() => results[1] = Sum(20000),
                    TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            parent.Start();

            parent.ContinueWith(t => Array.ForEach(t.Result, r => Console.WriteLine(r)));
        }

        private int Sum(int limit)
        {
            int sum = 0;

            for (int i = 0; i < limit; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
