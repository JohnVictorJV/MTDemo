using System;
using Automatonymous;

namespace Saga.Console2.StateMachines
{
    public class AllocationState : SagaStateMachineInstance
    {
       
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }
    }
}