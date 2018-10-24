using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IVehicleModel : IEntity
    {
        string Name { get; set; }
        IVehicleMark Mark { get; set; }
    }
}
