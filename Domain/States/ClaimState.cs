using System;
using System.Linq.Expressions;
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

        public virtual void Close(Action action)
        {
            throw new ClaimException("Action not allowed at this time");
        }

        public virtual void AssignPolicy(Action action)
        {
            throw new ClaimException("Action not allowed at this time");
        }

        public void ReOpen(Action action)
        {
            throw new ClaimException("Action not allowed at this time");
        }
    }
}