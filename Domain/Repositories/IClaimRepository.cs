using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClaimRepository
    {
        Claim GetById(ClaimId id);
        void Save(Claim claim);
    }
}
