namespace Message.Contracts.Events
{
   
    public interface IEventA
    {
        public string  NameA { get;  }
    }

    public interface IEventB : IEventA
    {
        public string NameB { get; }
    }

    public interface IEventC : IEventB
    {
        public string NameC { get; }
    }
    public interface IEventD : IEventC
    {
        public string NameD { get; }
    }

    public interface IEventE : IEventD
    {
        public string NameE { get; }
    }

    public interface IEventF :IEventE
    {
        public string NameF { get; }
    }

    public interface IEventG : IEventF
    {
        public string NameG { get; }
    }

    public interface IEvent1
    {
        public string Name1 { get; }
    }

    public interface IEvent2
    {
        public string Name2 { get; }
    }
    public interface IEvent3
    {
        public string Name3 { get; }
    }

    public interface IEventG123 : IEventG, IEvent1, IEvent2, IEvent3
    {
        public string NameG123 { get; }
    }

}