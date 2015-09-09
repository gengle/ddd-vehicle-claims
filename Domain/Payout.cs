using System;

namespace Domain
{
    public class Payout : IEquatable<Payout>
    {
        public Payout(decimal amount)
        {
            Amount = amount;
        }
        public bool Equals(Payout other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Payout) obj);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }

        public static bool operator <(Payout left, Payout right)
        {
            return left.Amount < right.Amount;
        }

        public override string ToString()
        {
            return $"{Amount:C2}";
        }

        public static bool operator >(Payout left, Payout right)
        {
            return left.Amount > right.Amount;
        }

        public static bool operator ==(Payout left, Payout right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Payout left, Payout right)
        {
            return !Equals(left, right);
        }

        public decimal Amount { get; private set; }

        public bool HasValue()
        {
            return this.Amount > 0;
        }

    }
}