using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.DTOs
{
    public class TruckEntityDTO
    {
        public int Mileage { get; set; }
        public int OilChangeMileage { get; set; }
        public int TireFDMileage { get; set; }
        public int TireFPMileage { get; set; }
        public int TireRDMileage { get; set; }
        public int TireRPMileage { get; set; }
        public RouteEntityDTO? Route { get; set; }
    }
}
