using System;
using System.Threading;

namespace CSharp.Threads.Examples.Basics
{
    public class MultipleCores
    {
        public void Execute()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                var thread = new Thread(DoSomething);
                thread.Start();
            }
        }

        static void DoSomething()
        {
            while (true)
                Console.WriteLine("Do something!");
        }
    }
}
