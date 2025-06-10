using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Entities
{
    public class MaintenanceEntity
    {
        [Key]
        public int id;
        [Required]
        public int Mileage;
        [ForeignKey("Truck")]
        public int TruckId;
        public TruckEntity? Truck;
        [Required]
        public decimal Cost;
        [Required]
        public string? Description;
        [Required]
        public DateTime Date { get; set; }

        public MaintenanceEntity() { }

        public MaintenanceEntity(int mileage, decimal cost, string description, DateTime date,TruckEntity Truck ,int TruckId)
        {
            this.Mileage = mileage;
            this.Cost = cost;
            this.Description = description;
            this.Date = date;
            this.Truck = Truck;
            this.TruckId = TruckId;

        }
    }
}
