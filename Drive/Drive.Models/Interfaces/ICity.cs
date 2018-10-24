using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface ICity : IEntity
    {
        string Name { get; set; }
        IList<IPostCode> PostCodes { get; set; }
        IList<IStreet> Streets { get; set; }
        ICountry Country { get; set; }
    }
}
