using System;

namespace Domain
{
    public class ClaimNo : IEquatable<ClaimNo>
    {
        public string Value { get; }
        
        public static ClaimNo Empty { get; } = new ClaimNo(string.Empty);

        public ClaimNo(string value)
        {
            Value = value;
        }

        public bool Equals(ClaimNo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return StringComparer.OrdinalIgnoreCase.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ClaimNo) obj);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        public static bool operator ==(ClaimNo left, ClaimNo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ClaimNo left, ClaimNo right)
        {
            return !Equals(left, right);
        }
        public override string ToString()
        {
            return this.Value;
        }

        public bool IsEmpty()
        {
            return Empty.Equals(this);
        }
    }
}