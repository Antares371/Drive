using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class VehicleSettings : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public virtual Unit DistanceUnit { get; set; }
        public virtual Unit MotorCapacityUnit { get; set; }
        public virtual Unit MotorPowerUnit { get; set; }
        public virtual Unit PetrolConsumptionUnit { get; set; }
        public virtual Unit TankCapacityUnit { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
