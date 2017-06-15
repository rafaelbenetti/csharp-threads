using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Threads.Examples.Async_Await
{
    class FileReader
    {
        internal static string Read()
        {
            Thread.Sleep(3000);

            var content = "Content of the file.";
            Console.WriteLine(content);
            return content;
        }

        internal static async Task<string> ReadAsync()
        {
            return await Task.Run(() => Read());
        }
    }
}
