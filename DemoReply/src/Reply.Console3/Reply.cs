using System;
using System.Threading.Tasks;
using MassTransit;
using Message.Contracts.Commands;

namespace Reply.Console3
{
    

    public class EventAConsumer : IConsumer<ICommandA>
    {
        public async Task Consume(ConsumeContext<ICommandA> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameA);

            await context.RespondAsync<IReplyA>(new
            {
                //PlanGuid = "2.16.840.1.114337.1.1.1505163998.0"
                NameA = "Response : A"
            });
            
        }
    }
    public class EventBConsumer : IConsumer<ICommandB>
    {
        public async Task  Consume(ConsumeContext<ICommandB> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameB);
            await context.RespondAsync<IReplyB>(new
            {
                //PlanGuid = "2.16.840.1.114337.1.1.1505163998.0"
                NameB = "Response : B"
            });
            
        }
    }
    public class EventCConsumer : IConsumer<ICommandC>
    {
        public async Task Consume(ConsumeContext<ICommandC> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameC);
            await context.RespondAsync<IReplyC>(new
            {
                //PlanGuid = "2.16.840.1.114337.1.1.1505163998.0"
                NameC = "Response : C"
            });
        }
    }
    public class EventDConsumer : IConsumer<ICommandD>
    {
        public async  Task Consume(ConsumeContext<ICommandD> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameD);
            Console.WriteLine();
            await context.RespondAsync<IReplyD>(new
            {
                //PlanGuid = "2.16.840.1.114337.1.1.1505163998.0"
                NameD = "Response : D"
            });
        }
    }
    public class EventEConsumer : IConsumer<ICommandE>
    {
        public async Task Consume(ConsumeContext<ICommandE> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameE);
            await context.RespondAsync<IReplyE>(new
            {
                //PlanGuid = "2.16.840.1.114337.1.1.1505163998.0"
                NameE = "Response : E"
            });
        }
    }
    public class EventFConsumer : IConsumer<ICommandF>
    {
        public async Task Consume(ConsumeContext<ICommandF> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameF);
            await context.RespondAsync<IReplyF>(new
            {
                //PlanGuid = "2.16.840.1.114337.1.1.1505163998.0"
                NameF = "Response : F"
            });
        }
    }
    public class EventGConsumer : IConsumer<ICommandG>
    {
        public async Task Consume(ConsumeContext<ICommandG> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Consumed {0}", context.Message.NameG);
            await context.RespondAsync<IReplyG>(new
            {
                //PlanGuid = "2.16.840.1.114337.1.1.1505163998.0"
                NameG = "Response : G"
            });
        }
    }
    
}