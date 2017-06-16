using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Threads.Examples.Lock
{
    class BathroomStallSincronized
    {
        static object _baton = new object();

        /// <summary>
        /// Why is this intelligent?
        /// Because you encapsulates the lock statment and it prevents to access the danger zone withour permission.
        /// </summary>
        /// <param name="name"></param>
        public void BeUsed(string name)
        {
            lock (_baton)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Being used by {name}");
                    Thread.Sleep(500);
                }
            }
        }
    }
    class LockIntelligentWay
    {
        static BathroomStallSincronized stall = new BathroomStallSincronized();

        internal static void Execute()
        {
            for (int i = 0; i < 3; i++)
                new Thread(RegularUsers).Start();
            new Thread(TheWeirdGuy).Start();
        }

        static void RegularUsers()
        {
            stall.BeUsed(Thread.CurrentThread.ManagedThreadId.ToString());
        }
        
        static void TheWeirdGuy()
        {
            stall.BeUsed("The Weird Guy");
        }
    }
}
