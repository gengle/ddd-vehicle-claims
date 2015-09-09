using Autofac;
using Domain.Repositories;
using Domain.Services;
using Domain.Shared;

namespace Domain.Infrastructure
{
    public class AutofacCommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        private readonly Repositories.IClaimRepository _claimRepository;

        public AutofacCommandDispatcher(IComponentContext context, IClaimRepository claimRepository)
        {
            this._context = context;
            _claimRepository = claimRepository;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = this._context.Resolve<ICommandHandler<TCommand>>();

            var claim = _claimRepository.GetById(ClaimId.FromString(command.Id));
            handler.Handle(command, claim);
        }
    }
}