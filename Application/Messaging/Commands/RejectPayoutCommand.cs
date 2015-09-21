using Application.Services;
using Core;

namespace Application.Messaging.Commands
{
    public class RejectPayoutCommand : ICommand
    {
        public string Id { get; set; }
    }
}