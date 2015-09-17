using System;
using System.Threading;
using Domain;
using Domain.Services;

namespace Application.Services
{
    public class AcmePolicyService
        :IPolicyService
    {
        public ClaimNo GenerateClaimNo(PolicyNo policyNo)
        {
            return new ClaimNo($"{policyNo}:{DateTime.UtcNow:HHmmss}");
        }
    }
}
