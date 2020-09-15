using System;
using System.Threading.Tasks;
using MassTransit;
using Message.Contracts.Events;

namespace Subscribe.Console3
{
    

    public class EventAConsumer : IConsumer<IEventA>
    {
        public  Task Consume(ConsumeContext<IEventA> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameA);
            return Task.CompletedTask;
        }
    }
    public class EventBConsumer : IConsumer<IEventB>
    {
        public Task Consume(ConsumeContext<IEventB> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameB);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class EventCConsumer : IConsumer<IEventC>
    {
        public Task Consume(ConsumeContext<IEventC> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameC);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class EventDConsumer : IConsumer<IEventD>
    {
        public Task Consume(ConsumeContext<IEventD> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameD);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class EventEConsumer : IConsumer<IEventE>
    {
        public Task Consume(ConsumeContext<IEventE> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameE);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class EventFConsumer : IConsumer<IEventF>
    {
        public Task Consume(ConsumeContext<IEventF> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameF);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class EventGConsumer : IConsumer<IEventG>
    {
        public Task Consume(ConsumeContext<IEventG> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameG);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class Event1Consumer : IConsumer<IEvent1>
    {
        public Task Consume(ConsumeContext<IEvent1> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.Name1);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class Event2Consumer : IConsumer<IEvent2>
    {
        public Task Consume(ConsumeContext<IEvent2> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.Name2);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class Event3Consumer : IConsumer<IEvent3>
    {
        public Task Consume(ConsumeContext<IEvent3> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.Name3);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
    public class EventG123Consumer : IConsumer<IEventG123>
    {
        public Task Consume(ConsumeContext<IEventG123> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameG123);
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }

}