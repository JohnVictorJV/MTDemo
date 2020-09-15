using System;
using System.Threading.Tasks;
using MassTransit;
using Message.Contracts.Events;

namespace Reply.Console1
{
    public class Event1Consumer : IConsumer<IEvent1>
    {
        public  Task Consume(ConsumeContext<IEvent1> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subscribed {0}", context.Message.Name1);
            return Task.CompletedTask;
        }
    }

    public class Event2Consumer : IConsumer<IEvent2>
    {
        public Task Consume(ConsumeContext<IEvent2> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subscribed {0}", context.Message.Name2);
            return Task.CompletedTask;
        }
    }
    public class Event3Consumer : IConsumer<IEvent3>
    {
        public Task Consume(ConsumeContext<IEvent3> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subscribed {0}", context.Message.Name3);
            return Task.CompletedTask;
        }
    }
    public class EventG123Consumer : IConsumer<IEventG123>
    {
        public Task Consume(ConsumeContext<IEventG123> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subcribed {0}", context.Message.NameG123);
            return Task.CompletedTask;
        }
    }

}