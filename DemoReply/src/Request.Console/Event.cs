using Message.Contracts.Events;

namespace Request.Console
{
    class EventA : IEventA
    {
        public string NameA { get; set; }
    }

    class EventB : IEventB
    {
        public string NameA { get; set; }
        public string NameB { get; set; }
    }

    class EventC : IEventC
    {
        public string NameA { get; set; }
        public string NameB { get; set; }
        public string NameC { get; set; }
    }

    class EventD : IEventD
    {
        public string NameA { get; set; }
        public string NameB { get; set; }
        public string NameC { get; set; }
        public string NameD { get; set; }
    }

    class EventE : IEventE
    {
        public string NameA { get; set; }
        public string NameB { get; set; }
        public string NameC { get; set; }
        public string NameD { get; set; }
        public string NameE { get; set; }
    }

    class EventF : IEventF
    {
        public string NameA { get; set; }
        public string NameB { get; set; }
        public string NameC { get; set; }
        public string NameD { get; set; }
        public string NameE { get; set; }
        public string NameF { get; set; }
    }

    class EventG : IEventG
    {
        public string NameA { get; set; }
        public string NameB { get; set; }
        public string NameC { get; set; }
        public string NameD { get; set; }
        public string NameE { get; set; }
        public string NameF { get; set; }
        public string NameG { get; set; }
    }

    class Event1 :IEvent1
    {
        public string Name1 { get; set; }

    }
    class Event2: IEvent2
    {

        public string Name2 { get; set; }
    }
    class Event3: IEvent3
    {
        public string Name3 { get; set; }
    }

    class EventG123 : IEventG123
    {
        public string NameA { get; set; }
        public string NameB { get; set; }
        public string NameC { get; set; }
        public string NameD { get; set; }
        public string NameE { get; set; }
        public string NameF { get; set; }
        public string NameG { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string NameG123 { get; set; }
    }
}