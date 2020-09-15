using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Message.Contracts.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Publish.Console
{
    public class MessagePublisherService : BackgroundService
    {
        readonly IBus _bus;
        private readonly ILogger _logger;
        public MessagePublisherService(IBus bus, ILogger<MessagePublisherService> logger)
        {
            _bus = bus;
            _logger = logger;
           
        }
        
        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                 try
                 {
                    System.Console.WriteLine("~~~~~~~~~~~START~~~~~~~~~~~~~~");
                    System.Console.ReadLine();
                     await _bus.Publish<IEventA>(new EventA
                     {
                         NameA = "Event:A",
                     }, ct);
                     System.Console.WriteLine($"Published:  Event:A");
                     System.Console.ReadLine();
                     await _bus.Publish<EventB>(new EventB
                     {
                         NameA = "Event:A",
                         NameB = "Event:B",
                     }, ct);
                     System.Console.WriteLine($"Published:  Event:B");

                     System.Console.ReadLine();
                     await _bus.Publish<EventC>(new EventC
                     {
                         NameA = "Event:A",
                         NameB = "Event:B",
                         NameC = "Event:C",
                     }, ct);
                     System.Console.WriteLine($"Published:  Event:C");

                     System.Console.ReadLine();
                     await _bus.Publish<EventD>(new EventD
                     {
                         NameA = "Event:A",
                         NameB = "Event:B",
                         NameC = "Event:C",
                         NameD = "Event:D"
                     }, ct); 
                     System.Console.WriteLine($"Published:  Event:D");

                     System.Console.ReadLine();
                     await _bus.Publish<EventE>(new EventE
                     {
                         NameA = "Event:A",
                         NameB = "Event:B",
                         NameC = "Event:C",
                         NameD = "Event:D",
                         NameE = "Event:E"
                     }, ct);
                     System.Console.WriteLine($"Published:  Event:E");

                     System.Console.ReadLine();
                     await _bus.Publish<EventF>(new EventF
                     {
                         NameA = "Event:A",
                         NameB = "Event:B",
                         NameC = "Event:C",
                         NameD = "Event:D",
                         NameE = "Event:E",
                         NameF = "Event:F",
                     }, ct);
                     System.Console.WriteLine($"Published:  Event:F");

                     

                     System.Console.ReadLine();
                     await _bus.Publish<IEventG>(new EventG
                     {
                         NameA = "Event:A",
                         NameB = "Event:B",
                         NameC = "Event:C",
                         NameD = "Event:D",
                         NameE = "Event:E",
                         NameF = "Event:F",
                         NameG = "Event:G"
                     }, ct);
                     System.Console.WriteLine($"Published:  Event:G");

                     System.Console.ReadLine();
                     await _bus.Publish<IEventG123>(new EventG123
                     {
                         NameA = "Event:A",
                         NameB = "Event:B",
                         NameC = "Event:C",
                         NameD = "Event:D",
                         NameE = "Event:E",
                         NameF = "Event:F",
                         NameG = "Event:G",
                         Name1 = "Event:1",
                         Name2 = "Event:2",
                         Name3 = "Event:3",
                         NameG123 = "Event:G123"
                     }, ct);
                     System.Console.WriteLine($"Published:  Event:G123");

                    System.Console.WriteLine("~~~~~~~~~~~~END~~~~~~~~~~~~~~");

                    
                    await Task.Delay(1000 * 10, ct);
                 }
                catch (Exception ex)
                {

                    System.Console.WriteLine("Exp: " + ex);
                    _logger.LogError(ex, "An error occurred.");
                }
            }

            
            //return _bus.StartAsync(stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
            //return Task.WhenAll(base.StopAsync(cancellationToken), _bus.StopAsync(cancellationToken));
        }
    }
}