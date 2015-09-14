using Domain;
using Domain.Services;

namespace Application.Services
{
    public class AcmeUnderwritingService
        :IUnderwritingService
    {
        public void ProcessPayout(PolicyNo policy, Payout payout)
        {
            //do nothing
        }

        public void CancelPayout(PolicyNo policyNo, Payout payout)
        {
            //do nothing
        }
    }
}
