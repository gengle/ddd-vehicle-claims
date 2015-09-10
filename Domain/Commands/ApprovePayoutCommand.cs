using Domain.Infrastructure;
using Domain.Shared;

namespace Domain.Commands
{
    public class ApprovePayoutCommand : ICommand
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
    }
}