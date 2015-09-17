using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Messaging.Commands;
using Core;
using Domain.Services;
using Domain.States;

namespace Application.Services
{
    public class RoutingRelationService
    {
        private HashSet<RoutingSlip> Routes = new HashSet<RoutingSlip>()
        {
            RoutingSlip.For<OpenedClaim>()
                .Relate<AssignVehicleCommand>()
                .Relate<CloseClaimCommand>(),
            RoutingSlip.For<RequestingApproval>()
                .Relate<ApprovePayoutCommand>()
                .Relate<RejectPayoutCommand>()
                .Relate<AssignVehicleCommand>(),
            RoutingSlip.For<ApprovedClaim>()
                .Relate<RejectPayoutCommand>()
                .Relate<CloseClaimCommand>(),
            RoutingSlip.For<RejectedClaim>()
                .Relate<ApprovePayoutCommand>()
                .Relate<CloseClaimCommand>(),
            RoutingSlip.For<ClosedClaim>()
                .Relate<ReopenClaimCommand>()
        };

        public IEnumerable<string> GetRelations(string forType)
        {
            var relations =
                Routes.Where(x => x.WhenType.FullName == forType)
                .SelectMany(x=>x.RelatedTypes);
            
            foreach(var relation in relations)
                yield return relation.Name;
        }
    }
}
