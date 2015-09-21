using System;
using Domain.Services;

namespace Domain.States
{
    public class NewClaim : ClaimState
    {
        public NewClaim(Claim context) : base(context)
        {
        }

        public override void AssignPolicy(Action action)
        {
            action();
            Context.CurrentState = new OpenedClaim(this.Context);
        }
    }
}