using System;
using Message.Contracts.Events;

namespace Saga.Initiator.Console
{
    internal class EventInitialCreateEvent : IInitialCreateEvent
    {
        public string Name { get; set; }
        public Guid PatientId { get; set; }
    }
}