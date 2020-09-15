using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Message.Contracts.Commands;
using Message.Contracts.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Request.Console
{
    public class MessageRequestPublisherService : BackgroundService
    {
        readonly IBus _bus;
        private readonly ILogger _logger;
        public MessageRequestPublisherService(IBus bus, ILogger<MessageRequestPublisherService> logger)
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
                    var clientA = _bus.CreateRequestClient<ICommandA>();

                    //Console.WriteLine("Sending command and waiting for reply.........");

                    var replyA = await clientA.GetResponse<IReplyA>(new
                    {
                        NameA = "Request: A"
                    }, ct);
                    System.Console.WriteLine("Received Reply from :{0}", replyA.Message.NameA);



                    var clientB = _bus.CreateRequestClient<ICommandB>();
                    var replyB = await clientB.GetResponse<IReplyB>(new
                    {
                        NameB = "Request: B"
                    }, ct, timeout: TimeSpan.FromSeconds(10));
                    System.Console.WriteLine("Received Reply from :{0}", replyB.Message.NameB);
                   
                    var clientC = _bus.CreateRequestClient<ICommandC>();
                    var replyC = await clientC.GetResponse<IReplyC>(new
                    {
                        NameC = "Request: C"
                    });
                    System.Console.WriteLine("Received Reply from :{0}", replyC.Message.NameC);


                    var clientD = _bus.CreateRequestClient<ICommandD>(); 
                    var replyD = await clientD.GetResponse<IReplyD>(new
                    {
                        NameD = "Request: D"
                    });
                    System.Console.WriteLine("Received Reply from :{0}", replyD.Message.NameD);

                    var clientE = _bus.CreateRequestClient<ICommandE>();
                    var replyE = await clientE.GetResponse<IReplyE>(new
                    {
                        NameE = "Request: E"
                    });
                    System.Console.WriteLine("Received Reply from :{0}", replyE.Message.NameE);

                    var clientF = _bus.CreateRequestClient<ICommandF>();
                    var replyF = await clientF.GetResponse<IReplyF>(new
                    {
                        NameF = "Request: F"
                    });
                    System.Console.WriteLine("Received Reply from :{0}", replyF.Message.NameF);

                    var clientG = _bus.CreateRequestClient<ICommandG>();
                    var replyG = await clientG.GetResponse<IReplyG>(new
                    {
                        NameG = "Request: G"
                    });
                    System.Console.WriteLine("Received Reply from :{0}", replyG.Message.NameG);

                    await _bus.Publish<IEvent1>(new Event1
                    {
                        Name1 = "name1"
                    });
                    await _bus.Publish<IEvent2>(new Event2
                    {
                        Name2 = "name2"
                    });
                    await _bus.Publish<IEvent3>(new Event3
                    {
                        Name3 = "name3"
                    });
                   

                    System.Console.WriteLine("~~~~~~~~~~~~END~~~~~~~~~~~~~~");

                    await Task.Delay(1000 * 2, ct);
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