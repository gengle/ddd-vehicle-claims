using Core;
using Domain;

namespace Infrastructure.Services
{
    public interface ICommandHandler<in T> where T:ICommand
    {
        void Handle(T command, Claim claim);
    }
}