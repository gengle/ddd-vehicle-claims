using System.Threading;

namespace Domain.Infrastructure.Acme
{
    public class AcmePolicyService
        :Services.IPolicyService
    {
        private static int seed = 0;

        public ClaimNo GenerateClaimNo(PolicyNo policyNo)
        {
            var newSeed = Interlocked.Increment(ref seed);
            return new ClaimNo($"{policyNo.Value}:{newSeed:D5}");
        }
    }
}
