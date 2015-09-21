using System;
using System.Collections.Generic;
using Application.Services;
using Domain.States;

namespace Application
{
    public class RoutingSlip
    {
        public Type WhenType { get; set; }
        public List<Type> RelatedTypes = new List<Type>();

        public RoutingSlip(Type whenType)
        {
            WhenType = whenType;
        }

        public RoutingSlip Relate<T>() where T: ICommand
        {
            RelatedTypes.Add(typeof(T));
            return this;
        }

        public static RoutingSlip For<T>() where T: ClaimState
        {
            return new RoutingSlip(typeof(T));
        }
    }
}
