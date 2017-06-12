using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace CSharp.Threads.Examples.Thread_Pool
{
    public class Threading
    {
        public void Execute(int numberOfCores)
        {
            Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)numberOfCores;
            
            List<int> numbers = Enumerable.Range(1, 10000).ToList();
            DateTime start = DateTime.Now;

            foreach (var number in numbers)
            {
                ThreadPool.QueueUserWorkItem(DoSomething);
            }

            Console.WriteLine("{0} cores, difference in time: {1}", numberOfCores, DateTime.Now.Subtract(start));
        }

        private void DoSomething(object state)
        {
            for (int i = 0; i < 10000; i++) ;
        }        
    }
}
