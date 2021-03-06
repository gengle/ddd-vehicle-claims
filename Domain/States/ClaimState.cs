using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core;
using Domain.Services;

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
            throw new DomainException("Action not allowed at this time");
        }

        public virtual void RequestApproval()
        {
            throw new DomainException("Action not allowed at this time");
        }
        public virtual void Approve(Action action)
        {
            throw new DomainException("Action not allowed at this time");
        }

        public virtual void Reject(Action action)
        {
            throw new DomainException("Action not allowed at this time");
        }

        public virtual void Close(Action action)
        {
            throw new DomainException("Action not allowed at this time");
        }

        public virtual void AssignPolicy(Action action)
        {
            throw new DomainException("Action not allowed at this time");
        }

        public virtual void ReOpen(Action action)
        {
            throw new DomainException("Action not allowed at this time");
        }

        public static ClaimState FromString(string stateName, Claim claim)
        {
            return (ClaimState)Activator.CreateInstance(Type.GetType(stateName), claim);
        }
    }
}