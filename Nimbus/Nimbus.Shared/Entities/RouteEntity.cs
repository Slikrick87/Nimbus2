using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Entities
{
    public class RouteEntity
    {
        [Key] public int Id { get; set; }
        public string? nickName;

        
        [ForeignKey("TruckId")]
        public int? truckId { get; set; }
        public TruckEntity? truck { get; set; } 
        public ICollection<Address>? stops { get; set; }

        public RouteEntity() { }

        public RouteEntity(string nickName)
        {
            this.nickName = nickName;
            this.stops = new List<Address>();
        }
    }
}
