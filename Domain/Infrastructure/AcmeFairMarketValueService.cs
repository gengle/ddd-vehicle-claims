using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;

namespace Domain.Infrastructure
{
    public class AcmeFairMarketValueService: IFairMarketValueService
    {
        public decimal GetValue(Vehicle vehicle)
        {
            return (decimal) (((vehicle.Year)*10) + vehicle.GetHashCode());
        }
    }
}
