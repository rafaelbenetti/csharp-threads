using System;
using System.Threading;

namespace CSharp.Threads.Examples.Timers
{
    class CheckTime
    {
        private static Timer _timer;

        public void Execute()
        {
            Console.WriteLine("Checking status every 2 seconds:");

            _timer = new Timer(Status, null, Timeout.Infinite, Timeout.Infinite);

            // You don't set the time on the start, then you prevent to it execute Status before timer's declaration.
            _timer.Change(0, Timeout.Infinite);
        }

        private static void Status(object state)
        {
            Console.WriteLine("2 seconds has passed.");

            // Have the timer call this method again in 2 seconds.
            _timer.Change(2000, Timeout.Infinite);
        }
    }
}
