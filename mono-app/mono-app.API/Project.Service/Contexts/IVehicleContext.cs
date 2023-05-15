using Microsoft.EntityFrameworkCore;
using mono_app.API.Project.MVC.Models.Domain;

namespace mono_app.API.Project.Service.Contexts
{
    public interface IVehicleContext
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }

        Task<int> SaveChangesAsync();
    }
}
