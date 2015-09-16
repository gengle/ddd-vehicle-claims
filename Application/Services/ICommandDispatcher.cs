using Core;

namespace Application.Services
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
