namespace Message.Contracts.Commands
{
    public interface ICommandA
    {
        public string NameA { get; }
    }

    public interface ICommandB 
    {
        public string NameB { get; }
    }

    public interface ICommandC 
    {
        public string NameC { get; }
    }
    public interface ICommandD 
    {
        public string NameD { get; }
    }

    public interface ICommandE 
    {
        public string NameE { get; }
    }

    public interface ICommandF 
    {
        public string NameF { get; }
    }

    public interface ICommandG 
    {
        public string NameG { get; }
    }

    public interface ICommand1
    {
        public string Name1 { get; }
    }

    public interface ICommand2
    {
        public string Name2 { get; }
    }
    public interface ICommand3
    {
        public string Name3 { get; }
    }

    /// <summary>
    /// Never have command inherit interface. Do not do this
    /// </summary>
    public interface ICommandG123 : ICommandG, ICommand1, ICommand2, ICommand3
    {
        public string NameG123 { get; }
    }

}