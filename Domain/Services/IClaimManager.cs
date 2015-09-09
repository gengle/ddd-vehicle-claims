using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ClaimManager
    {
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
    }
}
