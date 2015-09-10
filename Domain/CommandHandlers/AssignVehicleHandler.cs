using Domain.Commands;
using Domain.Services;
using Domain.Shared;

namespace Domain.CommandHandlers
{
    public class AssignVehicleHandler : ICommandHandler<AssignVehicleCommand>
    {
        private readonly IVehicleService _vehicleService;

        public AssignVehicleHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public void Handle(AssignVehicleCommand command, Claim claim)
        {
            claim.AssignVehicle(command.Vehicle, _vehicleService);
        }
    }
}