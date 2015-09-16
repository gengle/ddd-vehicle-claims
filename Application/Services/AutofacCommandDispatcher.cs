using Autofac;
using Core;
using Domain;
using Domain.Repositories;

namespace Application.Services
{
    public class AutofacCommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        private readonly Domain.Repositories.IClaimRepository _claimRepository;

        public AutofacCommandDispatcher(IComponentContext context, IClaimRepository claimRepository)
        {
            this._context = context;
            _claimRepository = claimRepository;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var type = typeof (ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = this._context.Resolve(type);
            var claim = _claimRepository.GetById(ClaimId.FromString(command.Id));

            handler.Handle((dynamic) command, claim);
            _claimRepository.AddOrUpdate(claim);
        }
    }
}