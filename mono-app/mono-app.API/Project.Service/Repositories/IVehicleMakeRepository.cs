using mono_app.API.Project.MVC.Models.Domain;

namespace mono_app.API.Project.Service.Repositories
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);
        Task<VehicleMake> GetAsync(Guid id);
        Task<VehicleMake> AddAsync(VehicleMake vehicleMake);
        Task<VehicleMake> DeleteAsync(Guid id);
        Task<VehicleMake> UpdateAsync(Guid id, VehicleMake vehicleMake);
    }
}
