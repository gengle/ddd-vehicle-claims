using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ClaimView
    {
        public Guid Id { get; set; }
        public string PolicyNo { get; set; }
        public string ClaimNo { get; set; }
        public decimal Payout { get; set; }
        public string[] Routes { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int? VehicleYear { get; set; }
        public string VehicleVin { get; set; }
        public string ClaimState { get; set; }
    }
}
