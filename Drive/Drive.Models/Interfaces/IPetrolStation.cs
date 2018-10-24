using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IPetrolStation : IEntity
    {
        string Name { get; set; }
        IList<IAddress> Addresses { get; set; }
        IList<IFuel> Fuels { get; set; }
        IPetrolStationSettings Settings { get; set; }
    }
}
