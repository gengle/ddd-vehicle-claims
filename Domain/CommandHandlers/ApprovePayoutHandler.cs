using Domain.Commands;
using Domain.Services;
using Domain.Shared;

namespace Domain.CommandHandlers
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