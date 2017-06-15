using CSharp.Threads.Examples.Async_Await;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Threads.Examples
{
    class ProgramAsync
    {
        internal static void Execute()
        {
            // Async Await
            FileReader.Read();
            Console.WriteLine("Waits until read the file completes");

            FileReader.ReadAsync();
            Console.WriteLine("I can do more things While I wait.");
        }
    }
}
