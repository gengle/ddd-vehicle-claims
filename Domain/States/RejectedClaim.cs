namespace Domain.States
{
    public class RejectedClaim : ClaimState
    {
        public RejectedClaim(Claim context) : base(context)
        {
        }

        public override void Close()
        {
            Context._state = new ClosedClaim(this.Context);
        }
    }
}