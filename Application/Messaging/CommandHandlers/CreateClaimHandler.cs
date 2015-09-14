using Application.Messaging.Commands;
using Domain;
using Domain.Services;
using Infrastructure.Services;

namespace Application.Messaging.CommandHandlers
{
    public class CreateClaimHandler : ICommandHandler<CreateClaimCommand>
    {
        private readonly IPolicyService _policyService;

        public CreateClaimHandler(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        public void Handle(CreateClaimCommand command, Claim claim)
        {
            claim.AssignPolicy(PolicyNo.FromString(command.PolicyNo), _policyService);
        }
    }
}