using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.DTOs
{
    public class AddressEntityDTO
    {
        public int streetNumber { get; set; }
        public string? streetName { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public int? zip { get; set; }
    }
}
