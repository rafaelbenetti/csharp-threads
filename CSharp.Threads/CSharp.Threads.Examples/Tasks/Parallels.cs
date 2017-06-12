using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Threads.Examples.Tasks
{
    public class Parallels
    {
        public void Execute()
        {
            // Parallel using for
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Parallel.For(0, 10, i => Console.WriteLine(i));

            // Parallel using foreach
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Parallel.ForEach(numbers, number => Console.WriteLine(number));

            // Parallel using invoke
            Console.WriteLine("Primeiro item.");
            Console.WriteLine("Segundo item.");
            Console.WriteLine("Terceiro item.");

            Parallel.Invoke(
                () => Console.WriteLine("Primeiro item."),
                () => Console.WriteLine("Segundo item."),
                () => Console.WriteLine("Terceiro item."));
        }
    }
}
