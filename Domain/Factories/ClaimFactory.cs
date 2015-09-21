using System;
using Domain.States;

namespace Domain.Factories
{
    public class ClaimFactory
    {
        public Claim FromMemento(ClaimMemento memento)
        {
            if (memento == null) return null;

            var claim = new Claim(new ClaimId(memento.Id));
            claim.PolicyNo = new PolicyNo(memento.PolicyNo);
            claim.ClaimNo = new ClaimNo(memento.ClaimNo);
            claim.Payout = new Payout(memento.Payout);
            claim.Vehicle = memento.Vehicle;
            claim.CurrentState = ClaimState.FromString(memento.ClaimState, claim);
            
            return claim;
        }
    }
}