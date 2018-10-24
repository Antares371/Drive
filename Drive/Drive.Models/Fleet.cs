using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class Fleet : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        public string Name { get; set; }
        public IList<Person> People { get; set; }
        public IList<Vehicle> Vehicles { get; set; }
    }
}
