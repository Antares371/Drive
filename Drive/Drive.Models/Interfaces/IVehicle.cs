using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IVehicle : IEntity
    {
        string Name { get; set; }
        IVehicleMark Mark { get; set; }
        IVehicleModel Model { get; set; }
        string Version { get; set; }
        string RegistrationNumber { get; set; }
        int Power { get; set; }
        double Capacity { get; set; }
        double TankCapacity { get; set; }
        double BeginTotalDistance { get; set; }
        double CurrentTotalDistance { get; set; }
        int ProductionYear { get; set; }
        DateTime? DateOfPurchase { get; set; }
        ICountry ProductionCountry { get; set; }
        IFuelType FuelType { get; set; }
        IList<IRefueling> Refuelings { get; set; }
        string VIN { get; set; }
        IList<IPerson> Owners { get; set; }
        double MaxConsumption { get; }
        double MinConsumption { get; }
        double AverageConsumption { get; }
        double MaxRange { get; }
        double MinRange { get; }
        double AverageRange { get; }
        IVehicleSettings Settings { get; set; }
    }
}
