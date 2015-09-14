using Core;

namespace Application.Messaging.Commands
{
    public class CloseClaimCommand : ICommand
    {
        public string Id { get; set; }
    }
}