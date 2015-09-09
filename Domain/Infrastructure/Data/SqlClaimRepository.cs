using System;

namespace Domain.Infrastructure.Data
{
    public class SqlClaimRepository
        :Repositories.IClaimRepository
    {
        public Claim GetById(ClaimId id)
        {
            throw new NotImplementedException();
        }

        public void Save(Claim claim)
        {
            throw new NotImplementedException();
        }
    }
}
