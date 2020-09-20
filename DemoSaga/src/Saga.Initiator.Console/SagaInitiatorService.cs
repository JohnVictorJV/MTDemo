using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Message.Contracts.Events;
using Microsoft.Extensions.Hosting;

namespace Saga.Initiator.Console
{
    internal class SagaInitiatorService : BackgroundService
    {
        private readonly IBusControl _bus;
        public SagaInitiatorService(IBusControl bus)
        {
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    System.Console.WriteLine("Please enter key to publish the message ....");
                    System.Console.ReadLine();

                    Task[] taskResult = new Task[10];
                    for (var i = 0; i < 10; i++)
                    {
                        taskResult[i] =(Task.Factory.StartNew(() =>
                            {
                                var msg = new EventInitialCreateEvent
                                {
                                    Name = "Initial Event Created",
                                    PatientId = Guid.NewGuid()
                                };

                                _bus.Publish<IInitialCreateEvent>(msg, ct);

                                System.Console.WriteLine("Published " + "IInitialCreateEvent :" + msg.PatientId);
                            }, ct)
                        );

                    }

                    Task.WaitAll(taskResult);
                }
                catch (Exception)
                {
                    // ignored
                }
            }//while
        }
    }
}