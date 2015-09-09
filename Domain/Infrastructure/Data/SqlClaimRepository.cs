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

        public void AddOrUpdate(Claim claim)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
