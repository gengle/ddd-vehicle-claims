using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Services;
using Domain;
using Domain.Repositories;
using Domain.States;

namespace DDDUserGroup.Controllers
{
    public class ClaimsController : ApiController
    {
        private readonly IClaimRepository _claimRepository;
        private readonly RoutingRelationService _routingRelationService;

        public ClaimsController(IClaimRepository claimRepository, 
            RoutingRelationService routingRelationService)
        {
            _claimRepository = claimRepository;
            _routingRelationService = routingRelationService;
        }

        // /api/claims
        public IHttpActionResult GetAllClaims()
        {
            var results = 
            _claimRepository.GetAll().OrderBy(x=>x.ClaimNo).ToList();

            return Ok(results.Select(x => new
                {
                    x.Id,
                    x.PolicyNo,
                    x.ClaimNo,
                    x.ClaimState,
                    Routes = _routingRelationService.GetRelations(x.ClaimState),
                    x.Payout,
                    x.Vehicle
                }));
        }

        // /api/claims/{id}
        public IHttpActionResult GetClaim(string id)
        {
            var claim= _claimRepository.GetById(ClaimId.FromString(id));
            return Ok(claim.GetMemento());
        }
    }
}
