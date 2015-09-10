using Domain.Infrastructure;
using Domain.Shared;

namespace Domain.Commands
{
    public class AssignVehicleCommand : ICommand
    {
        public string Id { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}