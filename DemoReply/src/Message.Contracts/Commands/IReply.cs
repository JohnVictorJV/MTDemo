namespace Message.Contracts.Commands
{
    public interface IReplyA
    {
        public string NameA { get; }
    }

    public interface IReplyB : IReplyA
    {
        public string NameB { get; }
    }

    public interface IReplyC : IReplyB
    {
        public string NameC { get; }
    }
    public interface IReplyD : IReplyC
    {
        public string NameD { get; }
    }

    public interface IReplyE : IReplyD
    {
        public string NameE { get; }
    }

    public interface IReplyF : IReplyE
    {
        public string NameF { get; }
    }

    public interface IReplyG : IReplyF
    {
        public string NameG { get; }
    }

    public interface IReply1
    {
        public string Name1 { get; }
    }

    public interface IReply2
    {
        public string Name2 { get; }
    }
    public interface IReply3
    {
        public string Name3 { get; }
    }

    /// <summary>
    /// Never have Reply inherit interface. Do not do this
    /// </summary>
    public interface IReplyG123 : IReplyG, IReply1, IReply2, IReply3
    {
        public string NameG123 { get; }
    }

}