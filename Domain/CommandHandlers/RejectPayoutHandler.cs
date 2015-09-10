using Domain.Commands;
using Domain.Services;
using Domain.Shared;

namespace Domain.CommandHandlers
{
    public class RejectPayoutHandler : ICommandHandler<RejectPayoutCommand>
    {
        private readonly IUnderwritingService _underwritingService;

        public RejectPayoutHandler(IUnderwritingService underwritingService)
        {
            _underwritingService = underwritingService;
        }

        public void Handle(RejectPayoutCommand command, Claim claim)
        {
            claim.RejectPayout(Payout.Zilch, _underwritingService);
        }
    }
}