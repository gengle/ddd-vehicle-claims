using System;
using System.Linq;

namespace Domain
{
    public class Unit : IEquatable<Unit>
    {
        public int UnitNo { get; }
        public Vehicle Vehicle { get; }
        public decimal? MonetaryAssessment { get; private set; }

        protected Unit(int unitNo, Vehicle vehicle = null, decimal? monetaryAssessment = null)
        {
            UnitNo = unitNo;
            Vehicle = vehicle;
            MonetaryAssessment = monetaryAssessment;
        }

        public bool Equals(Unit other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return UnitNo == other.UnitNo;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as Unit;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            return UnitNo;
        }

        public static bool operator ==(Unit left, Unit right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Unit left, Unit right)
        {
            return !Equals(left, right);
        }

        public Unit WithMonetaryAssessment(decimal value)
        {
            return new Unit(this.UnitNo, this.Vehicle, value);
        }

        public static Unit Create(Claim claim)
        {
            var unitNo = (claim.Units.Any() ? claim.Units.Max(x => x.UnitNo) : 0) + 1;
            return new Unit(unitNo);
        }

        public Unit WithVehicle(Vehicle vehicle)
        {
            return new Unit(this.UnitNo, vehicle, this.MonetaryAssessment);
        }
    }
}