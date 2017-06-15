using CSharp.Threads.Examples.Basics;
using System;

namespace CSharp.Threads.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Timer
            //var check = new CheckTime();
            //check.Execute();

            //Console.ReadKey();

            // Tasks
            //var blocking = new Blocking();
            //blocking.Execute();

            //var nonBlocking = new NonBlocking();
            //nonBlocking.ExecuteNonBlocking();

            //var multiple = new Multiple();
            //multiple.Execute();

            //var dependencies = new Dependencies();
            //dependencies.Execute();

            //var parallels = new Parallels();
            //parallels.Execute();

            //var threading = new Threading();
            //threading.Execute(1);
            //threading.Execute(2);
            //threading.Execute(3);
            //threading.Execute(4);
            //threading.Execute(5);
            //threading.Execute(6);
            //threading.Execute(7);
            //threading.Execute(8);

            // Basics
            //var multipleCores = new MultipleCores();
            //multipleCores.Execute();

            ProgramAsync.Execute();

            Console.ReadKey();
        }
    }
}
