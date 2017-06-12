using System;
using System.Threading.Tasks;

namespace CSharp.Threads.Examples.Tasks
{
    public class Dependencies
    {
        public void Execute()
        {
            var solution = new Task(() =>
            {
                var taskFactory = new TaskFactory(
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.AttachedToParent);

                Task d = taskFactory.StartNew(() => WriteLine("d"));
                Task e = taskFactory.StartNew(() => WriteLine("e"));
                Task f = taskFactory.StartNew(() => WriteLine("f"));

                Task b = d.ContinueWith(t => WriteLine("b"));

                Task c = taskFactory.ContinueWhenAll(new Task[] { e, f },
                    tasks => WriteLine("c"));

                Task a = taskFactory.ContinueWhenAll(new Task[] { b, c },
                    tasks => WriteLine("a"));
            });

            // Must log (d, e, f) the order doesn't matter
            // Must log (b, c, a) the order matter
            solution.Start();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
