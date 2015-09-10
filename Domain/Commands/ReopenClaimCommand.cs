using Domain.Shared;

namespace Domain.Commands
{
    public class ReopenClaimCommand : ICommand
    {
        public string Id { get; set; }
    }
}