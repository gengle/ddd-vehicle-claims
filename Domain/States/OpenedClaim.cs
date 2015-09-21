using System;

namespace Domain.States
{
    public class OpenedClaim : ClaimState
    {
        public OpenedClaim(Claim context) : base(context)
        {
        }

        public override void AssignVehicle(Action action)
        {
            action();
            Context.CurrentState = new RequestingApproval(this.Context);
        }

        public override void Close(Action action)
        {
            action();
            Context.CurrentState = new ClosedClaim(this.Context);
        }
    }
}