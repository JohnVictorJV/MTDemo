using System;
using Automatonymous;

namespace Saga.Console1.StateMachines
{
    public class AllocationState : SagaStateMachineInstance
    {
       
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }
    }
}