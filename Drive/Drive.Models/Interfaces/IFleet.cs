using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IFleet : IEntity
    {
        string Name { get; set; }
        IList<IPerson> People { get; set; }
        IList<IVehicle> Vehicles { get; set; }
    }
}
