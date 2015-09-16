using System;
using System.Collections.Generic;

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

        public RoutingSlip Relate<T>()
        {
            RelatedTypes.Add(typeof(T));
            return this;
        }

        public static RoutingSlip For<T>()
        {
            return new RoutingSlip(typeof(T));
        }
    }
}
