using Core;

namespace Application.Messaging.Commands
{
    public class ApprovePayoutCommand : ICommand
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
    }
}