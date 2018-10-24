using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class Vehicle : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public string Name { get; set; }
        public virtual IList<Person> Owners { get; set; }
        public virtual VehicleMark Mark { get; set; }
        public virtual VehicleModel Model { get; set; }
        public string Version { get; set; }
        public string RegistrationNumber { get; set; }
        public int Power { get; set; }
        public double Capacity { get; set; }
        public double TankCapacity { get; set; }
        public double BeginTotalDistance { get; set; }
        private double currentTotalDistance;
        public double CurrentTotalDistance
        {
            get
            {
                if(Refuelings.Count == 0)
                {
                    currentTotalDistance = BeginTotalDistance;
                }
                else
                {
                    currentTotalDistance = Refuelings.Max(r => r.TotalDistance);
                }

                return currentTotalDistance;
            }
            set { currentTotalDistance = value; }
        }
        public int ProductionYear { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public virtual Country ProductionCountry { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual IList<Refueling> Refuelings { get; set; }
        public string VIN { get; set; }
        public double MaxConsumption
        {
            get
            {
                if(Refuelings.Count == 0)
                {
                    return 0;
                }

                return Refuelings.Max(r =>
                {
                    if(r.ToFull)
                    {
                        return CalculateConsumPer100DistanceUnit(r);
                    }

                    return 0;
                });
            }
        }
        public double MinConsumption
        {
            get
            {
                if(Refuelings.Count == 0)
                {
                    return 0;
                }

                return Refuelings.Min(r =>
                {
                    if(r.ToFull)
                    {
                        return CalculateConsumPer100DistanceUnit(r);
                    }

                    return 0;
                });
            }
        }
        public double AverageConsumption
        {
            get
            {
                if(Refuelings.Count == 0)
                {
                    return 0;
                }

                return Refuelings.Average(r =>
                {
                    if(r.ToFull)
                    {
                        return CalculateConsumPer100DistanceUnit(r);
                    }

                    return 0;
                });
            }
        }
        public double MaxRange
        {
            get
            {
                if(Refuelings.Count == 0)
                {
                    return 0;
                }

                return Refuelings.Max(r =>
                {
                    if(!r.ToFull)
                    {
                        return 0;
                    }

                    return TankCapacity * CalculateDistancePer1FuelUnit(r);
                });
            }
        }
        public double MinRange
        {
            get
            {
                if(Refuelings.Count == 0)
                {
                    return 0;
                }

                return Refuelings.Min(r =>
                {
                    if(!r.ToFull)
                    {
                        return 0;
                    }

                    return TankCapacity * CalculateDistancePer1FuelUnit(r);
                });
            }
        }
        public double AverageRange
        {
            get
            {
                if(Refuelings.Count == 0)
                {
                    return 0;
                }

                return Refuelings.Average(r =>
                {
                    if(!r.ToFull)
                    {
                        return 0;
                    }

                    return TankCapacity * CalculateDistancePer1FuelUnit(r);
                });
            }
        }
        public VehicleSettings Settings { get; set; } 

        public Vehicle()
        {
            Refuelings = new List<Refueling>();
        }

        private double CalculateConsumPer100DistanceUnit(Refueling r)
        {
            return CalculateConsumPer1DistanceUnit(r) * 100;
        }

        private double CalculateConsumPer1DistanceUnit(Refueling r)
        {
            return ((double)r.Quantity / r.Distance);
        }

        private double CalculateDistancePer1FuelUnit(Refueling r)
        {
            return r.Distance / (double)r.Quantity;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2} {3}", Name, Mark.Name, Model.Name, RegistrationNumber);
        }

    }
}
