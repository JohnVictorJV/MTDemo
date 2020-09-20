using System;
using Message.Contracts.Events;

namespace Saga.Console1
{
    class EventInitialCreateEvent : IInitialCreateEvent
    {
        public string Name { get; set; }
        public Guid PatientId { get; set; }
    }
    
    class EventInitialCreatedEvent : IInitialCreatedEvent
    {
        public string Name { get; set; }
        public Guid PatientId { get; set; }
    }
    class CompletedWork1 : ICompletedWork1
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    
    class MoveToNextWork1 : IMoveToNextWork1
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class CompletedWork2 : ICompletedWork2
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class MoveToNextWork2 : IMoveToNextWork2
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class CompletedWork3 : ICompletedWork3
    {
        public Guid PatientId { get; }
        public string Name { get; set; }
    }
    class MoveToNextWork3 : IMoveToNextWork3
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class CompletedWork4 : ICompletedWork4
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class MoveToNextWork4 : IMoveToNextWork4
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class CompletedWork5 : ICompletedWork5
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class MoveToNextWork5 : IMoveToNextWork5
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class RetryCurrentWork : IRetryCurrentWork
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }

    
    class ErrorCurrentWork : IErrorCurrentWork
    {
        public string Name { get; set; }

        public Guid PatientId { get; set; }
    }
    class ExceptionCurrentWork : IExceptionCurrentWork
    {

        public string Name { get; set; }
        public Guid PatientId { get; set; }
    }
    class FatalCurrentWork : IFatalCurrentWork
    {
        public string Name { get; set; }
        public Guid PatientId { get; set; }
    }

    class FinalCompletedWork : IFinalCompletedWork
    {
        
        public string Name { get; set; }
        public Guid PatientId { get; set; }
    }
}