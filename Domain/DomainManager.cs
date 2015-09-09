using System;
using Domain.Services;

namespace Domain
{
    public class DomainManager: IDisposable
    {
        private readonly IPolicyService _policyService;
        private readonly IFairMarketValueService _fairMarketValueService;

        public DomainManager(IPolicyService policyService, IFairMarketValueService fairMarketValueService)
        {
            _policyService = policyService;
            _fairMarketValueService = fairMarketValueService;
        }

        public ClaimId NewClaimId()
        {
            return new ClaimId(Guid.NewGuid());
        }

        public void Dispose()
        {
            
        }

        public Claim LoadOrCreate(ClaimId id)
        {
            return new Claim(id);
        }

        public IPolicyService PolicyService()
        {
            return _policyService;
        }
    }
}
