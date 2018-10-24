using Drive.Models;
using System;
using System.Data.Entity;

namespace Drive.DataBase
{
    public class DriveDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Fleet> Fleets { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Refueling> Refuelings { get; set; }
        public DbSet<VehicleMark> VehiclesMarks { get; set; }
        public DbSet<VehicleModel> VehiclesModels { get; set; }
        public DbSet<PetrolStation> PetrolStations { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<PostCode> PostCodes { get; set; }

        public DriveDbContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DriveManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            Database.SetInitializer(new DriveDbContextInitializer());
            this.Configuration.LazyLoadingEnabled = true;
        }

        public static bool TestConnection(DbContext context)
        {
            try
            {
                context.Database.Connection.Open();
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                if(context.Database.Connection.State != System.Data.ConnectionState.Closed)
                {
                    context.Database.Connection.Close();
                }
            }
            return true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(p => p.Name == "ID").Configure(p => p.IsKey());

            base.OnModelCreating(modelBuilder);
        }

    }
}
