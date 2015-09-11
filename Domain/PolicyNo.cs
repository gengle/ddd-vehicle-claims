using System;
using System.Security.AccessControl;

namespace Domain
{
    public class PolicyNo : IEquatable<PolicyNo>
    {
        public string Value { get; }
        public static PolicyNo Empty { get; } = new PolicyNo(string.Empty);

        public PolicyNo(string value)
        {
            Value = value;
        }

        public bool Equals(PolicyNo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (PolicyNo)) return false;
            return Equals((PolicyNo) obj);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        public static bool operator ==(PolicyNo left, PolicyNo right)
        {
            return Equals(left, right);
        }

        public static implicit operator string (PolicyNo policyNo)  // explicit byte to digit conversion operator
        {
            return policyNo?.Value;
        }

        public static bool operator !=(PolicyNo left, PolicyNo right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"Value: {Value}";
        }

        public static PolicyNo FromString(string value)
        {
            return new PolicyNo(value);
        }

        public bool IsEmpty()
        {
            return Empty.Equals(this);
        }
    }
}