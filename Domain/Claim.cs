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
        public ClaimState _state;

        #region Properties
        public ClaimId Id { get; }

        public Claim(ClaimId id)
        {
            this.Id = id;
            _state = new NewClaim(this);
        }

        public ClaimNo ClaimNo { get; set; } = Domain.ClaimNo.Empty;

        public Payout Payout { get; set; } = Domain.Payout.Zilch;

        public PolicyNo PolicyNo { get; set; } = Domain.PolicyNo.Empty;
        public Vehicle Vehicle { get; set; } = Domain.Vehicle.Empty;

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
            Services.IVehicleService vehicleService)
        {
            _state.AssignVehicle(() =>
            {
                Guard.NotNull(() => vehicle, vehicle);
                Guard.NotNull(() => vehicleService, vehicleService);

                vehicleService.ValidateVehicle(vehicle);
                this.Vehicle = vehicle;
            });
        }

        public void ApprovePayout(Payout payout, IUnderwritingService underwritingService)
        {
            Guard.NotNull(() => payout, payout);
            Guard.NotNull(() => underwritingService, underwritingService);

            _state.Approve(() =>
            {
                underwritingService.ProcessPayout(this.PolicyNo, payout);
                this.Payout = payout;
            });
        }

        public void RejectPayout(Payout payout, IUnderwritingService underwritingService)
        {
            _state.Reject(() =>
            {
                underwritingService.CancelPayout(this.PolicyNo, this.Payout);
                this.Payout = Payout.Zilch;
            });
        }
        #endregion

        public void Reopen()
        {
            _state.ReOpen(() => Expression.Empty());
        }

        public void Close()
        {
            _state.Close(()=>Expression.Empty());
        }

        public ClaimMemento GetMemento(ClaimMemento memento = null)
        {
            var m = memento ?? new ClaimMemento();
            if (m.Id == default(Guid))
                m.Id = this.Id;
            m.PolicyNo = this.PolicyNo;
            m.ClaimNo = this.ClaimNo;
            m.Payout = this.Payout;
            m.Vehicle = this.Vehicle;
            m.ClaimState = this._state.GetType().ToString();
            return m;
        }
    }
}
