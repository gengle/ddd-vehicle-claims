using Application.Messaging.Commands;
using Domain;
using Domain.Services;
using Infrastructure.Services;

namespace Application.Messaging.CommandHandlers
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