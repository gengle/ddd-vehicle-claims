using System;

namespace Domain
{
    [Serializable]
    public class ClaimMemento
    {
        public Guid Id { get; set; }
        public string PolicyNo { get; set; }
        public string ClaimNo { get; set; }
        public decimal Payout { get; set; }
        public Vehicle Vehicle { get; set; } = new Vehicle();
        public string ClaimState { get; set; }
    }
}