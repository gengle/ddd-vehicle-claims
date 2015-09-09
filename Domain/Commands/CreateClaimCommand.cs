using Domain.Infrastructure;
using Domain.Shared;

namespace Domain.Commands
{
    public class CreateClaimCommand : ICommand
    {
        public string Id { get; set; }
        public string PolicyNo { get; set; }
    }
}