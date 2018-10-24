
using Drive.Models.Interfaces;
using Drive.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Drive.DataBase
{
    public class DriveDbContextInitializer : CreateDatabaseIfNotExists<DriveDbContext>
    {
        protected override void Seed(DriveDbContext context)
        {
            InitCountries(context);
            InitCarsMarks(context);
            InitFuelsTypes(context);
            context.SaveChanges();
            InitPetrolStations(context);
            context.SaveChanges();

            InitVehicles(context); 

            base.Seed(context);
        }

        private void InitCountries(DriveDbContext context)
        {
            IList<Country> defaultCountries = new List<Country>();
            var city1 = new City() { Name = "Pakość" };
            var city2 = new City() { Name = "Inowrocław" };
            var city3 = new City() { Name = "Bydgoszcz" };
            var city4 = new City() { Name = "Gdańsk" };

            city1.Streets.Add(new Street() { Name = "Pakoska" });
            city1.PostCodes.Add(new PostCode() { Code = "88-147" });

            city2.Streets.Add(new Street() { Name = "Bydgoska" });
            city2.Streets.Add(new Street() { Name = "Mikołaja Kopernika" });
            city2.PostCodes.Add(new PostCode() { Code = "88-178" });
            city2.PostCodes.Add(new PostCode() { Code = "88-171" });

            city3.Streets.Add(new Street() { Name = "Nakielska" });
            city3.Streets.Add(new Street() { Name = "Fordońska" });
            city3.Streets.Add(new Street() { Name = "Bernardyńska" });
            city3.PostCodes.Add(new PostCode() { Code = "88-125" });
            city4.PostCodes.Add(new PostCode() { Code = "88-127" });

            city4.Streets.Add(new Street() { Name = "Morska" });
            city4.PostCodes.Add(new PostCode() { Code = "70-107" });



            Country polishCountry = new Country() { Name = "Polska", ShortName = "POL" };
            polishCountry.Cities.Add(city1);
            polishCountry.Cities.Add(city2);
            polishCountry.Cities.Add(city3);
            polishCountry.Cities.Add(city4);
            defaultCountries.Add(polishCountry);

            context.Countries.AddRange(defaultCountries);
        }

        private void InitCarsMarks(DriveDbContext context)
        {
            List<VehicleMark> defaultVehiclesMarks = new List<VehicleMark>();

            VehicleMark opelMark = new VehicleMark() { Name = "Opel" };
            opelMark.Models.Add(new VehicleModel("Corsa"));
            opelMark.Models.Add(new VehicleModel("Astra"));
            opelMark.Models.Add(new VehicleModel("Insignia"));

            VehicleMark fordMark = new VehicleMark() { Name = "Ford" };
            fordMark.Models.Add(new VehicleModel("Mondeo"));
            fordMark.Models.Add(new VehicleModel("Focus"));

            VehicleMark mazdaMark = new VehicleMark() { Name = "Mazda" };
            mazdaMark.Models.Add(new VehicleModel("3"));
            mazdaMark.Models.Add(new VehicleModel("6"));

            defaultVehiclesMarks.Add(opelMark);
            defaultVehiclesMarks.Add(fordMark);
            defaultVehiclesMarks.Add(mazdaMark);

            context.VehiclesMarks.AddRange(defaultVehiclesMarks);
        }

        private void InitFuelsTypes(DriveDbContext context)
        {
            IList<FuelType> defaultFuelsTypes = new List<FuelType>()
            {
                new FuelType() { Name = "Diesel" },
                new FuelType() { Name = "Benzyna" }
            };

            context.FuelTypes.AddRange(defaultFuelsTypes);

        }

        private void InitVehicles(DriveDbContext context)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.Name = "Mazda";
            vehicle.Capacity = 1600;
            vehicle.DateOfPurchase = new DateTime(2018, 05, 07);
            vehicle.Power = 109;
            vehicle.ProductionCountry = context.Countries.FirstOrDefault();
            vehicle.ProductionYear = 2005;
            vehicle.Version = "Sport";
            vehicle.VIN = "QWERTYU123";
            vehicle.FuelType = context.FuelTypes.FirstOrDefault();
            vehicle.Mark = context.VehiclesMarks.Where(m => m.Name == "Mazda").FirstOrDefault();
            vehicle.Model = vehicle.Mark.Models.SingleOrDefault(m => m.Name == "3"); //context.VehiclesModels.Where(m => m.Name == "3").FirstOrDefault();
            vehicle.RegistrationNumber = "CBA 70210";
            vehicle.BeginTotalDistance = 200000;
            vehicle.TankCapacity = 45;

            var petrolStation = context.PetrolStations.Include("Addresses").SingleOrDefault(ps => ps.Name == "Orlen");
            vehicle.Refuelings.Add(
                new Refueling()
                {
                    PetrolStation = petrolStation,
                    Address = petrolStation.Addresses[0],
                    Date = DateTime.Now.AddMonths(-3),
                    Fuel = petrolStation.Fuels[0],
                    Quantity = 42.25M,
                    TotalPrice = 212.36M,
                    Distance = 700.2,
                    TotalDistance = 200700.2
                });

            vehicle.Refuelings.Add(
                new Refueling()
                {
                    PetrolStation = petrolStation,
                    Address = petrolStation.Addresses[0],
                    Date = DateTime.Now.AddMonths(-2),
                    Fuel = petrolStation.Fuels[0],
                    Quantity = 41.7M,
                    TotalPrice = 208.11M,
                    Distance = 689.8,
                    TotalDistance = 201390.0
                });

            context.Vehicles.Add(vehicle);
        }

        private void InitPetrolStations(DriveDbContext context)
        {
            var polishCountry = context.Countries.SingleOrDefault(c => c.Name == "Polska");

            List<PetrolStation> defaultPetrolStations = new List<PetrolStation>();
            PetrolStation orlenPetrolStation = new PetrolStation("Orlen");
            orlenPetrolStation.Addresses.Add(
                new Address(polishCountry,
                polishCountry.Cities[2],
                polishCountry.Cities[2].Streets[0],
                polishCountry.Cities[2].PostCodes[0],
                "233"
            ));

            orlenPetrolStation.Addresses.Add(
                new Address(polishCountry,
                polishCountry.Cities[2],
                polishCountry.Cities[2].Streets[1],
                polishCountry.Cities[2].PostCodes[0],
                "15"
            ));


            orlenPetrolStation.Fuels.Add(new Fuel() { Name = "Verva ON" });
            orlenPetrolStation.Fuels.Add(new Fuel() { Name = "Verva Pb95" });
            orlenPetrolStation.Fuels.Add(new Fuel() { Name = "Verva Pb98" });

            PetrolStation lukoilPetrolStation = new PetrolStation("LukOil");
            lukoilPetrolStation.Addresses.Add(
                new Address(polishCountry,
                polishCountry.Cities[2],
                polishCountry.Cities[2].Streets[1],
                polishCountry.Cities[2].PostCodes[0],
                "73"
            ));

            lukoilPetrolStation.Fuels.Add(new Fuel() { Name = "ON" });
            lukoilPetrolStation.Fuels.Add(new Fuel() { Name = "Pb 95" });
            lukoilPetrolStation.Fuels.Add(new Fuel() { Name = "Pb 98" });

            defaultPetrolStations.Add(orlenPetrolStation);
            defaultPetrolStations.Add(lukoilPetrolStation);

            context.PetrolStations.AddRange(defaultPetrolStations);

        }
    }
}
