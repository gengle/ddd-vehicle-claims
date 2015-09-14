using Application.Messaging.Commands;
using Domain;
using Domain.Services;
using Infrastructure.Services;

namespace Application.Messaging.CommandHandlers
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