using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IVehicleSettings: IEntity
    {
        IUnit DistanceUnit { get; set; }
        IUnit MotorCapacityUnit { get; set; }
        IUnit MotorPowerUnit { get; set; }
        IUnit PetrolConsumptionUnit { get; set; }
        IUnit TankCapacityUnit { get; set; }
        List<IVehicle> Vehicles { get; set; }
    }
}
