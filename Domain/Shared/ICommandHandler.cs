namespace Domain.Shared
{
    public interface ICommandHandler<in T> where T:ICommand
    {
        void Handle(T command, Claim claim);
    }
}