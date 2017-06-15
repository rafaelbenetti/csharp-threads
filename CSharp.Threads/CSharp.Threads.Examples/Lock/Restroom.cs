using System;
using System.Threading;

namespace CSharp.Threads.Examples.Lock
{
    class Restroom
    {
        private static object _objectToControlLock = new object();
        private static Random _random = new Random();

        internal static void Enter()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                var thread = new Thread(enter);
                thread.Start();
            }
        }

        private static void enter()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} trying to obtain the bathroom stall...");

            lock(_objectToControlLock)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} obtained the lock. Doing my business...");
                Thread.Sleep(_random.Next(3000));
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} I am done!");
            }

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is leaving the restaurant.");
        }

        /// <summary>
        /// This is what really happens when you use lock keyword.
        /// </summary>
        private static void whatReallyHappensInLock()
        {
            bool locked = false;

            try
            {
                Monitor.Enter(_objectToControlLock, ref locked);
            }
            finally
            {
                if (locked)
                    Monitor.Exit(_objectToControlLock);
            }
        }
    }
}
