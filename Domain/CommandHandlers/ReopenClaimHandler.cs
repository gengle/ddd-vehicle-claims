using Domain.Commands;
using Domain.Shared;

namespace Domain.CommandHandlers
{
    public class ReopenClaimHandler : ICommandHandler<ReopenClaimCommand>
    {
        public void Handle(ReopenClaimCommand command, Claim claim)
        {
            claim.Reopen();
        }
    }
}