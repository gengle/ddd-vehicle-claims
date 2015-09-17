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
            return new ClaimNo($"{policyNo.Value}:{DateTime.UtcNow:HHmmss}");
        }
    }
}
