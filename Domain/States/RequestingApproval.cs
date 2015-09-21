using System;
using Domain.Services;

namespace Domain.States
{
    public class RequestingApproval : ClaimState
    {
        public RequestingApproval(Claim context) : base(context)
        {
        }

        public override void AssignVehicle(Action action)
        {
            action();
            Context.CurrentState = new RequestingApproval(this.Context);
        }

        public override void Approve(Action action)
        {
            action();
            Context.CurrentState = new ApprovedClaim(this.Context);
        }

        public override void Reject(Action action)
        {
            action();
            Context.CurrentState = new RejectedClaim(this.Context);
        }
    }
}