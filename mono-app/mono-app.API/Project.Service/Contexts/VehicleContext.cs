using Microsoft.EntityFrameworkCore;
using mono_app.API.Project.MVC.Models.Domain;

namespace mono_app.API.Project.Service.Contexts
{
    public class VehicleContext : DbContext, IVehicleContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseSqlServer(WebApplication.CreateBuilder().Configuration.GetConnectionString("CarsConnectionString"));

        async Task<int> IVehicleContext.SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
