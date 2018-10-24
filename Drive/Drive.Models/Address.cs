using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class Address : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual Street Street { get; set; }
        public virtual PostCode PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string ApartamentNumber { get; set; }

        public Address()
        {

        }

        public Address(Country country, City city, Street street, PostCode postCode, string houseNumber, string apartamentNumber = "")
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            ApartamentNumber = apartamentNumber;
            PostCode = postCode;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3} {4}", Country?.ShortName, City?.Name, PostCode?.Code, Street?.Name, HouseNumber);
        }
    }
}
