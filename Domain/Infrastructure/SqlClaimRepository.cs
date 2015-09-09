using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure
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
