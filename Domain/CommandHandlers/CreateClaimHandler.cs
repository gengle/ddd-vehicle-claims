using Domain.Commands;
using Domain.Services;
using Domain.Shared;

namespace Domain.CommandHandlers
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