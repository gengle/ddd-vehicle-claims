using Domain.Services;

namespace Domain.Infrastructure.Acme
{
    public class AcmeFairMarketValueService: IFairMarketValueService
    {
        public decimal GetValue(Vehicle vehicle)
        {
            return (decimal) (((vehicle.Year)*10) + vehicle.GetHashCode());
        }
    }
}
