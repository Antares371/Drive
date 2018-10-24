using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IStreet : IEntity
    {
        string Name { get; set; }
        ICity City { get; set; }
    }
}
