using System;
using Message.Contracts.Events;

namespace Client.PublishReply.console3
{
    class CompletedWork1 : ICompletedWork1
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }

    class CompletedWork2 : ICompletedWork2
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class CompletedWork3 : ICompletedWork3
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class CompletedWork4 : ICompletedWork4
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
    class CompletedWork5 : ICompletedWork5
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }

    class FinalCompletedWork : IFinalCompletedWork
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
    }
}