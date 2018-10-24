using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class Refueling : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public DateTime? Date { get; set; }
        public virtual PetrolStation PetrolStation { get; set; }
        public virtual Address Address { get; set; }
        public decimal Quantity { get; set; }
        public virtual Fuel Fuel { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PricePerUnit { get; set; }
        public double Distance { get; set; }
        public double TotalDistance { get; set; }
        public bool ToFull { get; set; }
        public bool TheCounterHasBeenReset { get; set; }

    }
}
