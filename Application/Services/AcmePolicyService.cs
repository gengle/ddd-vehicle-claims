using System.Threading;
using Domain;
using Domain.Services;

namespace Application.Services
{
    public class AcmePolicyService
        :IPolicyService
    {
        private static int seed = 0;

        public ClaimNo GenerateClaimNo(PolicyNo policyNo)
        {
            var newSeed = Interlocked.Increment(ref seed);
            return new ClaimNo($"{policyNo.Value}:{newSeed:D5}");
        }
    }
}
