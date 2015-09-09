using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Claim: IAggregateRoot<ClaimId>, IEquatable<Claim>
    {
        public ClaimId Id { get; }

        public Claim(ClaimId id)
        {
            
        }

        public ClaimNo ClaimNo { get; private set; } = Domain.ClaimNo.Empty;

        public HashSet<Unit> Units { get; } = new HashSet<Unit>();

        public Claim WithClaimNo(ClaimNo value)
        {
            if (!ClaimNo.IsEmpty())
                throw new ClaimException("Unable to change ClaimId Once set");
            ClaimNo = value;
            return this;
        }
        public Claim WithVehicle(Vehicle vehicle, 
            Services.IFairMarketValueService fairMarketValueService)
        {
            Guard.NotNull(()=>vehicle, vehicle);
            Guard.NotNull(() => fairMarketValueService, fairMarketValueService);

            var unit = Unit.Create(this)
                .WithVehicle(vehicle)
                .WithMonetaryAssessment(fairMarketValueService.GetValue(vehicle));
                            
            Units.Add(unit);
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

        public Claim AssignPolicy(PolicyInfo policyInfo)
        {
            return this;
        }
    }
}
