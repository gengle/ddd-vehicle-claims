using Application.Messaging.Commands;
using Domain;
using Infrastructure.Services;

namespace Application.Messaging.CommandHandlers
{
    public class ReopenClaimHandler : ICommandHandler<ReopenClaimCommand>
    {
        public void Handle(ReopenClaimCommand command, Claim claim)
        {
            claim.Reopen();
        }
    }
}