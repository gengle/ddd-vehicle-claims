using System;
using Application.Messaging.Commands;
using Application.Services;
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
            var policy = PolicyNo.FromString(command.PolicyNo);
            if (policy.IsEmpty())
                policy = PolicyNo.NewRandom();

            claim.AssignPolicy(policy, _policyService);
        }
    }
}