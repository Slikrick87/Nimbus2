using Nimbus.Shared.Entities;
using Nimbus.Shared.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Pages
{
    public partial class AddTruck
    {
        public int id;
        public int mileage;
        public string nickName;
        public TruckEntity truck;
        public int TruckId = 0;
        public int TruckMileage = 0;
        public async Task AddNewTruck()
        {
            truck = await TruckRepository.CreateNewTruckAsync(id, mileage, 0, 0, 0, 0, 0);
            await TruckRepository.AddTruckAsync(truck);

        }
    }
}
