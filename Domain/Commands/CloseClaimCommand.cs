using Domain.Shared;

namespace Domain.Commands
{
    public class CloseClaimCommand : ICommand
    {
        public string Id { get; set; }
    }
}