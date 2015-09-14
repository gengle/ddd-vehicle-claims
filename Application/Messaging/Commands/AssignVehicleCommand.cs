using Core;
using Domain;

namespace Application.Messaging.Commands
{
    public class AssignVehicleCommand : ICommand
    {
        public string Id { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}