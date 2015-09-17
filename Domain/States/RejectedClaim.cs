using System;

namespace Domain.States
{
    public class RejectedClaim : ClaimState
    {
        public RejectedClaim(Claim context) : base(context)
        {
        }

        public override void Close(Action action)
        {
            action();
            Context._state = new ClosedClaim(this.Context);
        }

        public override void Approve(Action action)
        {
            action();
            Context._state = new ApprovedClaim(this.Context);
        }
    }
}