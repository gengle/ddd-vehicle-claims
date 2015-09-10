using Domain.Commands;
using Domain.Shared;

namespace Domain.CommandHandlers
{
    public class CloseClaimHandler : ICommandHandler<CloseClaimCommand>
    {
        public void Handle(CloseClaimCommand command, Claim claim)
        {
            claim.Close();
        }
    }
}