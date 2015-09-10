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
            Context._state = new RequestingApproval(this.Context);
        }

        public override void Close()
        {
            Context._state = new ClosedClaim(this.Context);
        }
    }
}