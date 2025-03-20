using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.DTOs
{
    public class RouteEntityDTO
    {
        public ICollection<AddressEntityDTO>? stops { get; set; }

        public string? nickName { get; set; }
        public TruckEntityDTO? truck { get; set; }
    }
}
