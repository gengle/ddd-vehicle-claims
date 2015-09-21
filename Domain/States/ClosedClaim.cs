using System;

namespace Domain.States
{
    public class ClosedClaim : ClaimState
    {
        public ClosedClaim(Claim context) : base(context)
        {
        }

        public override void ReOpen(Action action)
        {
            action();
            Context.CurrentState = new OpenedClaim(this.Context);
        }
    }
}