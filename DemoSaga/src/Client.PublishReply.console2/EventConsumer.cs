using System;
using System.Threading.Tasks;
using MassTransit;
using Message.Contracts.Events;

namespace Client.PublishReply.console2
{
    
    public class EventInitialConsumer : IConsumer<IInitialCreatedEvent>
    {
        public async  Task Consume(ConsumeContext<IInitialCreatedEvent> context)
        {
            Console.WriteLine("Subscribed {0} :  {1}", context.Message.Name, context.Message.PatientId);
           
            await context.Publish<ICompletedWork1>(new CompletedWork1()
            {
                Name = "Completed the Work-1 : ",
                PatientId = context.Message.PatientId
            });
           
            
        }
    }

    public class Event1Consumer : IConsumer<IMoveToNextWork1>
    {
        public async Task Consume(ConsumeContext<IMoveToNextWork1> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subscribed {0} :  {1}", context.Message.Name, context.Message.PatientId);

            await context.Publish<ICompletedWork2>(new CompletedWork2()
            {
                Name = "Completed the Work-2 : ",
                PatientId = context.Message.PatientId
            });
        }
    }

    public class Event2Consumer : IConsumer<IMoveToNextWork2>
    {
        public async Task Consume(ConsumeContext<IMoveToNextWork2> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subscribed {0} :  {1}", context.Message.Name, context.Message.PatientId);

            await context.Publish<ICompletedWork3>(new CompletedWork3()
            {
                Name = "Completed the Work-3 : ",
                PatientId = context.Message.PatientId
            });
        }
    }

    public class Event3Consumer : IConsumer<IMoveToNextWork3>
    {
        public async Task Consume(ConsumeContext<IMoveToNextWork3> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subscribed {0} :  {1}", context.Message.Name, context.Message.PatientId);

            await context.Publish<ICompletedWork4>(new CompletedWork4()
            {
                Name = "Completed the Work-4 : ",
                PatientId = context.Message.PatientId
            });
        }
    }
    public class Event4Consumer : IConsumer<IMoveToNextWork4>
    {
        public async Task Consume(ConsumeContext<IMoveToNextWork4> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subscribed {0} :  {1}", context.Message.Name, context.Message.PatientId);

            await context.Publish<ICompletedWork5>(new CompletedWork5()
            {
                Name = "Completed the Work-5 : " ,
                PatientId = context.Message.PatientId
            });
        }
    }

    public class EventFinalizeConsumer : IConsumer<IMoveToNextWork5>
    {
        public async Task Consume(ConsumeContext<IMoveToNextWork5> context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(1));   // improved readability
            Console.WriteLine("Subscribed {0} :  {1}", context.Message.Name, context.Message.PatientId);

            await context.Publish<IFinalCompletedWork>(new FinalCompletedWork()
            {
                Name = "Completed the Final Work : " ,
                PatientId = context.Message.PatientId
            });
        }
    }
}