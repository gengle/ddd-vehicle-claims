using System;

namespace Domain.States
{
    public class ApprovedClaim : ClaimState
    {
        public ApprovedClaim(Claim context) : base(context)
        {
        }

        public override void Close(Action action)
        {
            action();
            Context._state = new ClosedClaim(this.Context);
        }

        public override void Reject(Action action)
        {
            action();
            Context._state = new RejectedClaim(this.Context);
        }
    }
}