using Domain.Infrastructure;
using Domain.Services;
using Domain.Shared;

namespace Domain.Commands.Handlers
{
    public class ProcessPayoutHandler : ICommandHandler<ProcessPayoutCommand>
    {
        private readonly IUnderwritingService _underwritingService;

        public ProcessPayoutHandler(IUnderwritingService underwritingService)
        {
            _underwritingService = underwritingService;
        }

        public void Handle(ProcessPayoutCommand command, Claim claim)
        {
            claim.ProcessPayout(new Payout(command.Amount), _underwritingService);
        }
    }
}