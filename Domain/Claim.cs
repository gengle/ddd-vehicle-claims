using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Core;
using Domain.Services;
using Domain.States;

namespace Domain
{
    public class Claim: IAggregateRoot<ClaimId>, IEquatable<Claim>
    {
        public ClaimState CurrentState { get; set; }

        #region Properties
        public ClaimId Id { get; }

        public Claim(ClaimId id)
        {
            this.Id = id;
            CurrentState = new NewClaim(this);
        }

        public ClaimNo ClaimNo { get; internal set; } = Domain.ClaimNo.Empty;

        public Payout Payout { get; internal set; } = Domain.Payout.Zilch;

        public PolicyNo PolicyNo { get; internal set; } = Domain.PolicyNo.Empty;
        public Vehicle Vehicle { get; internal set; } = Domain.Vehicle.Empty;

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
            CurrentState.AssignPolicy(() =>
            {
                Guard.NotNull(() => policyNo, policyNo);
                Guard.NotNull(() => policyService, policyService);
                if (policyNo.IsEmpty()) throw new DomainException("Unable to change Policy once set");

                if (!policyNo.Equals(PolicyNo) && !this.PolicyNo.IsEmpty())
                    throw new DomainException("Unable to change Policy once set");

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
            CurrentState.AssignVehicle(() =>
            {
                Guard.NotNull(() => vehicle, vehicle);
                Guard.NotNull(() => vehicleService, vehicleService);
                if (vehicle.IsEmpty()) throw new ArgumentNullException(nameof(vehicle));
                vehicleService.ValidateVehicle(vehicle);
                this.Vehicle = vehicle;
            });
        }

        public void ApprovePayout(Payout payout, IUnderwritingService underwritingService)
        {
            Guard.NotNull(() => payout, payout);
            Guard.NotNull(() => underwritingService, underwritingService);

            CurrentState.Approve(() =>
            {
                underwritingService.ProcessPayout(this.PolicyNo, payout);
                this.Payout = payout;
            });
        }

        public void RejectPayout(Payout payout, IUnderwritingService underwritingService)
        {
            CurrentState.Reject(() =>
            {
                underwritingService.CancelPayout(this.PolicyNo, this.Payout);
                this.Payout = Payout.Zilch;
            });
        }

        public void Reopen()
        {
            CurrentState.ReOpen(() => Expression.Empty());
        }

        public void Close()
        {
            CurrentState.Close(()=>Expression.Empty());
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
            m.ClaimState = this.CurrentState.GetType().ToString();
            return m;
        }
        #endregion
    }
}
