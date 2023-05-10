using mono_app.API.Models.Domain;

namespace mono_app.API.Repositories
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);
        Task<VehicleModel> GetAsync(Guid id);
        Task<VehicleModel> AddAsync(VehicleModel vehicleModel);
        Task<VehicleModel> DeleteAsync(Guid id);
        Task<VehicleModel> UpdateAsync(Guid id, VehicleModel vehicleModel);
    }
}
