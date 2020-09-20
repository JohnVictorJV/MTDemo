using GreenPipes;
using MassTransit;
using MassTransit.Definition;

namespace Saga.Console2.StateMachines
{
    public class AllocateStateMachineDefinition :
        SagaDefinition<AllocationState>
    {
        public AllocateStateMachineDefinition()
        {
            ConcurrentMessageLimit = 10;
        }

        protected override void ConfigureSaga(IReceiveEndpointConfigurator endpointConfigurator, ISagaConfigurator<AllocationState> sagaConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Interval(3, 1000));
            
            // important, otherwise may result in unhandled exception
            endpointConfigurator.UseInMemoryOutbox();
        }

    }
}