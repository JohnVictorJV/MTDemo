using System;

namespace Message.Contracts.Events
{
    public interface IEvent
    {
        public Guid PatientId { get; }
    }

    public interface IInitialCreateEvent : IEvent
    {

        public string Name { get; }
    }

    public interface IInitialCreatedEvent : IEvent
    {

        public string Name { get; }
    }

    public interface ICompletedWork1 : IEvent
    {
        public string Name { get; }
    }
    public interface IMoveToNextWork1 : IEvent
    {
        public string Name { get; }
    }

    public interface ICompletedWork2 : IEvent
    {
        public string Name { get; }
    }
    public interface IMoveToNextWork2 : IEvent
    {
        public string Name { get; }
    }

    public interface ICompletedWork3 : IEvent
    {
        public string Name { get; }
    }
    public interface IMoveToNextWork3 : IEvent
    {
        public string Name { get; }
    }

    public interface ICompletedWork4 : IEvent
    {
        public string Name { get; }
    }
    public interface IMoveToNextWork4 : IEvent
    {
        public string Name { get; }
    }

    public interface ICompletedWork5 : IEvent
    {
        public string Name { get; }
    }
    public interface IMoveToNextWork5 : IEvent
    {
        public string Name { get; }
    }

    public interface IRetryCurrentWork : IEvent
    {
        public string Name { get; }
    }

    public interface IErrorCurrentWork : IEvent
    {
        public string Name { get; }
    }

    public interface IExceptionCurrentWork : IEvent
    {
        public string Name { get; }
    }
    public interface IFatalCurrentWork : IEvent
    {
        public string Name { get; }
    }

    public interface IFinalCompletedWork : IEvent
    {
        public string Name { get; }
    }

    public interface ICompletedAllWork : IEvent
    {
        public string Name { get; }
    }
}