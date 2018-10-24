using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IRefueling : IEntity
    {
        DateTime? Date { get; set; }
        IPetrolStation PetrolStation { get; set; }
        IAddress Address { get; set; }
        decimal Quantity { get; set; }
        IFuel Fuel { get; set; }
        decimal TotalPrice { get; set; }
        decimal PricePerUnit { get; set; }
        double Distance { get; set; }
        double TotalDistance { get; set; }
        bool ToFull { get; set; }
        bool TheCounterHasBeenReset { get; set; }
    }
}
