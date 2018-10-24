using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface ICountry : IEntity
    {
        string Name { get; set; }
        string ShortName { get; set; }
        IList<ICity> Cities { get; set; }
    }
}
