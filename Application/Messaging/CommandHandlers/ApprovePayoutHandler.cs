using Application.Messaging.Commands;
using Domain;
using Domain.Services;
using Infrastructure.Services;

namespace Application.Messaging.CommandHandlers
{
    public class ApprovePayoutHandler : ICommandHandler<ApprovePayoutCommand>
    {
        private readonly IUnderwritingService _underwritingService;

        public ApprovePayoutHandler(IUnderwritingService underwritingService)
        {
            _underwritingService = underwritingService;
        }

        public void Handle(ApprovePayoutCommand command, Claim claim)
        {
            claim.ApprovePayout(new Payout(command.Amount), _underwritingService);
        }
    }
}