using System;
using Domain.Services;
using Domain.Shared;

namespace Domain.States
{
    public class ClaimState
    {
        protected readonly Claim Context;

        public ClaimState(Claim context)
        {
            Context = context;
        }

        public virtual void AssignVehicle(Action action)
        {
            throw new ClaimException("Action not allowed at this time");
        }

        public virtual void RequestApproval()
        {
            throw new ClaimException("Action not allowed at this time");
        }
        public virtual void Approve(Action action)
        {
            throw new ClaimException("Action not allowed at this time");
        }

        public virtual void Reject(Action action)
        {
            throw new ClaimException("Action not allowed at this time");
        }

        public virtual void Close()
        {
            throw new ClaimException("Action not allowed at this time");
        }

        public virtual Claim ProcessPayout()
        {
            throw new ClaimException("Action not allowed at this time");
        }

        public virtual void AssignPolicy(Action action)
        {
            throw new ClaimException("Action not allowed at this time");
        }
    }
}