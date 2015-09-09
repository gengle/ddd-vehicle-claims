using System.Collections.Generic;
using System.Linq;

namespace Domain.Infrastructure.Data
{
    public class MemoryClaimRepository
        : Repositories.IClaimRepository
    {
        private readonly HashSet<Claim> _claims = new HashSet<Claim>(); 

        public Claim GetById(ClaimId id)
        {
            var claim = _claims.FirstOrDefault(x => x.Id == id);
            if (claim == null)
            {
                claim = new Claim(id);
                _claims.Add(claim);
            }
            return claim;
        }

        public void Save(Claim claim)
        {
            //noop
        }
    }
}