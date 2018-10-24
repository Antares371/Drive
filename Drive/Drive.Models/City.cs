using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class City : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public string Name { get; set; }
        public virtual IList<PostCode> PostCodes { get; set; }
        public virtual IList<Street> Streets { get; set; }
        public virtual Country Country { get; set; }

        public City()
        {
            PostCodes = new List<PostCode>();
            Streets = new List<Street>();
        }

        public City(string name) : this()
        {
            Name = name;
        }

        public City(string name, Country country) : this(name)
        {
            Country = country;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
