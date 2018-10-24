using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IAddress : IEntity
    {
        ICountry Country { get; set; }
        ICity City { get; set; }
        IStreet Street { get; set; }
        IPostCode PostCode { get; set; }
        string HouseNumber { get; set; }
        string ApartamentNumber { get; set; }
    }
}
