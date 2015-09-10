using Domain.Shared;

namespace Domain.Commands
{
    public class RejectPayoutCommand : ICommand
    {
        public string Id { get; set; }
    }
}