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
            Context.CurrentState = new ClosedClaim(this.Context);
        }

        public override void Reject(Action action)
        {
            action();
            Context.CurrentState = new RejectedClaim(this.Context);
        }
    }
}