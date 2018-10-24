using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class PetrolStation : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public string Name { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public virtual IList<Fuel> Fuels { get; set; }
        public virtual PetrolStationSettings Settings { get; set; }

        public PetrolStation(string name) : this()
        {
            Name = name;
        }

        public PetrolStation()
        {
            Addresses = new List<Address>();
            Fuels = new List<Fuel>();
        }

    }


}
