using Domain.Infrastructure;
using Domain.Services;
using Domain.Shared;

namespace Domain.Commands.Handlers
{
    public class AssignVehicleHandler : ICommandHandler<AssignVehicleCommand>
    {
        private readonly IFairMarketValueService _fairMarketValueService;

        public AssignVehicleHandler(IFairMarketValueService fairMarketValueService)
        {
            _fairMarketValueService = fairMarketValueService;
        }

        public void Handle(AssignVehicleCommand command, Claim claim)
        {
            var vehicle = new Vehicle(command.Make, command.Model, command.Year, command.Vin);
            claim.AssignVehicle(vehicle, _fairMarketValueService);
        }
    }
}