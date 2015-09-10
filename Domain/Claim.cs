using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;
using Domain.Services;
using Domain.Shared;
using Domain.States;

namespace Domain
{
    public class Claim: IAggregateRoot<ClaimId>, IEquatable<Claim>
    {
        internal ClaimState _state;

        #region Properties
        public ClaimId Id { get; }

        public Claim(ClaimId id)
        {
            this.Id = id;
            _state = new NewClaim(this);
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

        public void AssignPolicy(PolicyNo policyNo, IPolicyService policyService)
        {
            _state.AssignPolicy(() =>
            {
                Guard.NotNull(() => policyNo, policyNo);
                Guard.NotNull(() => policyService, policyService);

                if (!policyNo.Equals(PolicyNo) && !this.PolicyNo.IsEmpty())
                    throw new ClaimException("Unable to change Policy once set");

                if (!policyNo.Equals(PolicyNo))
                {
                    this.PolicyNo = policyNo;
                    this.ClaimNo = policyService.GenerateClaimNo(policyNo);
                }
            });
        }

        public void AssignVehicle(Vehicle vehicle,
            Services.IFairMarketValueService fairMarketValueService)
        {
            _state.AssignVehicle(() =>
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
            });
        }

        public void OnProcessPayout(Payout payout, IUnderwritingService underwritingService)
        {
            Guard.NotNull(() => underwritingService, underwritingService);
            if (!payout.HasValue())
                throw new ClaimException("You are not allowed to process a payout for no money");

            if (payout > PendingPayout)
                throw new ClaimException($"{payout} is greater than pending {PendingPayout}");

            underwritingService.ProcessPayout(this.PolicyNo, payout);

            Payouts.Add(payout);
        }
        public Claim ProcessPayout(Payout payout, IUnderwritingService underwritingService)
        {
            return this;
        }
        #endregion

        public void ApprovePayout(Payout payout, IUnderwritingService underwritingService)
        {
            _state.Approve(() => Expression.Empty());
        }

        public void RejectPayout(Payout payout, IUnderwritingService underwritingService)
        {
            _state.Reject(() => Expression.Empty());
        }
    }
}
