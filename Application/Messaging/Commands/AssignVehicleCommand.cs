using Core;
using Domain;

namespace Application.Messaging.Commands
{
    public class AssignVehicleCommand : ICommand
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Vin { get; set; }
    }
}