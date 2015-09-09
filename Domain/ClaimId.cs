using System;

namespace Domain
{
    public class ClaimId : IEquatable<ClaimId>
    {
        public ClaimId(string value):this(Guid.ParseExact(value, "N"))
        {
            
        }
        public ClaimId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; private set; }

        public override string ToString()
        {
            return this.Value.ToString("N");
        }

        public bool Equals(ClaimId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ClaimId) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(ClaimId left, ClaimId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ClaimId left, ClaimId right)
        {
            return !Equals(left, right);
        }

        public static ClaimId NewId()
        {
            return new ClaimId(Guid.NewGuid());
        }

        public static ClaimId FromString(string id)
        {
            return new ClaimId(Guid.Parse(id));
        }
    }
}