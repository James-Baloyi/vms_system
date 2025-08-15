using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Common.Services.Farmers.Dto
{
    public class FarmerDetailsDto 
    {
        public Guid FarmerId { get; set; }
        public double? FarmSize { get; set; }
        public double? ProductionSize { get; set; }
        public int NumberOfActiveVouchers { get; set; }
        public int NumberOfEnrolledPrograms { get; set; }

    }
}
