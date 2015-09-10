using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUnderwritingService
    {
        void ProcessPayout(PolicyNo policy, Payout payout);
        void CancelPayout(PolicyNo policyNo, Payout payout);
    }
}
