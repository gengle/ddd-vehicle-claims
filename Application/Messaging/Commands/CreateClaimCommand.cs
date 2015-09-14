using Core;

namespace Application.Messaging.Commands
{
    public class CreateClaimCommand : ICommand
    {
        public string Id { get; set; }
        public string PolicyNo { get; set; }
    }
}