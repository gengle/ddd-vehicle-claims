﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;
using Domain.Services;
using Domain.Shared;

namespace Domain
{
    public class Claim: IAggregateRoot<ClaimId>, IEquatable<Claim>
    {
        #region Properties
        public ClaimId Id { get; }

        public Claim(ClaimId id)
        {
            this.Id = id;
        }

        public ClaimNo ClaimNo { get; set; } = Domain.ClaimNo.Empty;

        public HashSet<Unit> Units { get; set; } = new HashSet<Unit>();
        public HashSet<Payout> Payouts { get; set; } = new HashSet<Payout>();

        public Payout PendingPayout => new Payout(this.Units.Sum(x => x.MonetaryAssessment)
                                                  - this.Payouts.Sum(x => x.Amount));
        
        public PolicyNo PolicyNo { get; set; } = Domain.PolicyNo.Empty;
        #endregion

        #region Equals and Operator Overloads
        public bool Equals(Claim other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Claim) obj);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }

        public static bool operator ==(Claim left, Claim right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Claim left, Claim right)
        {
            return !Equals(left, right);
        }
        #endregion

        #region Aggregate Actions
        public Claim AssignPolicy(PolicyNo policyNo, IPolicyService policyService)
        {
            Guard.NotNull(()=>policyNo, policyNo);
            Guard.NotNull(()=>policyService, policyService);

            if (!policyNo.Equals(PolicyNo) && !this.PolicyNo.IsEmpty())
                throw new ClaimException("Unable to change Policy once set");

            if (!policyNo.Equals(PolicyNo))
            {
                this.PolicyNo = policyNo;
                this.ClaimNo = policyService.GenerateClaimNo(policyNo);
            }
            
            return this;
        }

        public Claim AssignVehicle(Vehicle vehicle,
            Services.IFairMarketValueService fairMarketValueService)
        {
            Guard.NotNull(() => vehicle, vehicle);
            Guard.NotNull(() => fairMarketValueService, fairMarketValueService);

            if (!Units.Any(x => x.Vehicle.Equals(vehicle)))
            {
                var unit = Unit.Create(this)
                    .WithVehicle(vehicle)
                    .WithMonetaryAssessment(fairMarketValueService.GetValue(vehicle));

                Units.Add(unit);
            }

            return this;
        }

        public Claim ProcessPayout(Payout payout, IUnderwritingService underwritingService)
        {
            Guard.NotNull(() => underwritingService, underwritingService);
            if (!payout.HasValue())
                throw new ClaimException("You are not allowed to process a payout for no money");

            if (payout > PendingPayout)
                throw new ClaimException($"{payout} is greater than pending {PendingPayout}");

            underwritingService.ProcessPayout(this.PolicyNo, payout);

            Payouts.Add(payout);
            return this;
        }
        #endregion
    }
}
