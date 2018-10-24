using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class VehicleModel : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public string Name { get; set; }
        public virtual VehicleMark Mark { get; set; }

        public VehicleModel()
        {

        }

        public VehicleModel(string name)
        {
            Name = name;
        }

        public VehicleModel(string name, VehicleMark mark) : this(name)
        {
            Mark = mark;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
