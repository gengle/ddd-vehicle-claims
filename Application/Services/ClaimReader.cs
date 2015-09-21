using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain;
using Domain.Repositories;

namespace Application.Services
{
    public class ClaimReader
    {
        private readonly IClaimRepository _claimRepository;
        private readonly RoutingRelationService _routingRelationService;

        public ClaimReader(RoutingRelationService routingRelationService, IClaimRepository claimRepository)
        {
            _routingRelationService = routingRelationService;
            _claimRepository = claimRepository;
        }

        protected ClaimView ClaimView(ClaimMemento memento)
        {
            return new ViewModels.ClaimView
            {
                Id = memento.Id,
                PolicyNo = memento.PolicyNo,
                ClaimNo = memento.ClaimNo,
                ClaimState = memento.ClaimState.Remove(0,14),
                Routes = _routingRelationService.GetRelations(memento.ClaimState).ToArray(),
                Payout = memento.Payout,
                VehicleMake = memento.Vehicle.Make,
                VehicleModel = memento.Vehicle.Model,
                VehicleYear = memento.Vehicle.Year,
                VehicleVin = memento.Vehicle.Vin,
            };
        }
        public IEnumerable<ClaimView> GetAll()
        {
            var results =_claimRepository.GetAll().OrderBy(x => x.ClaimNo).ToList();
            return results.Select(ClaimView);
        }

        public ClaimView GetById(string id)
        {
            var memento = _claimRepository.GetById(ClaimId.FromString(id)).GetMemento();
            return ClaimView(memento);
        }

        public ClaimView GetById(Guid id)
        {
            return GetById(id.ToString());
        }
    }
}
