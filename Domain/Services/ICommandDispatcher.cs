using Domain.Shared;

namespace Domain.Services
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
