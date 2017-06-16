using System;
using System.Threading;

namespace CSharp.Threads.Examples.Lock
{
    class BathroomStall
    {
        public void BeUsed(string name)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Being used by {name}");
                Thread.Sleep(500);
            }            
        }
    }
    class LockJustOnePart
    {
        static BathroomStall stall = new BathroomStall();
        
        internal static void Execute()
        {
            for (int i = 0; i < 3; i++)
                new Thread(RegularUsers).Start();
            new Thread(TheWeirdGuy).Start();
        }

        static void RegularUsers()
        {
            lock (stall)
                stall.BeUsed(Thread.CurrentThread.ManagedThreadId.ToString());
        }

        /// <summary>
        ///  Note that this guy doesn't use lock. It means that doesn't respect the danger zone.
        /// </summary>
        static void TheWeirdGuy()
        {
            //lock (stall)
                stall.BeUsed("The Weird Guy");
        }
    }
}
