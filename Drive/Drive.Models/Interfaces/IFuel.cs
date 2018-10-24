using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IFuel : IEntity
    {
        string Name { get; set; }
        IFuelType Type { get; set; }
    }
}
