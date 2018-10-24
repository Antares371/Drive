using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class Country : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }

        public Country(string name, string shortName) : this()
        {
            this.Name = name;
            this.ShortName = shortName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
