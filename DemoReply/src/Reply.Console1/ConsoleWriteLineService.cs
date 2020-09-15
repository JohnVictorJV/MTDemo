using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Reply.Console1
{
    public class ConsoleWriteLineService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            int i = 0;
            bool toggle = true;
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    if (i == 5)
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = toggle ? ConsoleColor.DarkRed : ConsoleColor.Black;
                        i = 0;
                        toggle = !toggle;
                        await Task.Delay(1000 * 5, ct);
                    }
                    Console.Write("~~");
                    await Task.Delay(1000 * 1, ct);
                    i++;
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            
        }
    }
}