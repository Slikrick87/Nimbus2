using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Logic
{
    public class TruckLogic
    {
        public TruckEntity AddTruck(int mileage, int tireFd, int tireRd, int tireFp, int tireRp, int oilChange)
        {
            return new TruckEntity(mileage, tireFd, tireRd, tireFp, tireRp, oilChange);
        }
    }
}
