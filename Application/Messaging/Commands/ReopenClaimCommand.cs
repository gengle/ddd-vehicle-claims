using Core;

namespace Application.Messaging.Commands
{
    public class ReopenClaimCommand : ICommand
    {
        public string Id { get; set; }
    }
}