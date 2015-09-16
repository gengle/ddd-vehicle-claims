using Application.Messaging.Commands;
using Application.Services;
using Domain;
using Infrastructure.Services;

namespace Application.Messaging.CommandHandlers
{
    public class CloseClaimHandler : ICommandHandler<CloseClaimCommand>
    {
        public void Handle(CloseClaimCommand command, Claim claim)
        {
            claim.Close();
        }
    }
}