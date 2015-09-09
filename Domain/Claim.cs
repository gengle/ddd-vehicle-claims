using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;
using Domain.Services;

namespace Domain
{
    public class Claim: IAggregateRoot<ClaimId>, IEquatable<Claim>
    {
        public ClaimId Id { get; }

        public Claim(ClaimId id)
        {
            this.Id = id;
        }

        public ClaimNo ClaimNo { get; private set; } = Domain.ClaimNo.Empty;

        public HashSet<Unit> Units { get; } = new HashSet<Unit>();
        public PolicyNo PolicyNo { get; private set; } = Domain.PolicyNo.Empty;

        public Claim AssignVehicle(Vehicle vehicle, 
            Services.IFairMarketValueService fairMarketValueService)
        {
            Guard.NotNull(()=>vehicle, vehicle);
            Guard.NotNull(() => fairMarketValueService, fairMarketValueService);

            if (!Units.Any(x => x.Vehicle.Equals(vehicle)))
            {
                var unit = Unit.Create(this)
                    .WithVehicle(vehicle)
                    .WithMonetaryAssessment(fairMarketValueService.GetValue(vehicle));

                Units.Add(unit);
            }
            
            return this;
        }

        public bool Equals(Claim other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Claim) obj);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }

        public static bool operator ==(Claim left, Claim right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Claim left, Claim right)
        {
            return !Equals(left, right);
        }

        public Claim AssignPolicy(PolicyNo policyNo, IPolicyService policyService)
        {
            Guard.NotNull(()=>policyNo, policyNo);
            Guard.NotNull(()=>policyService, policyService);

            if (!policyNo.Equals(PolicyNo) && !this.PolicyNo.IsEmpty())
                throw new ClaimException("Unable to change Policy once set");

            if (!policyNo.Equals(PolicyNo))
            {
                this.PolicyNo = policyNo;
                this.ClaimNo = policyService.GenerateClaimNo(policyNo);
            }
            
            return this;
        }
    }
}
