using AutoMapper;
using Microsoft.EntityFrameworkCore;
using mono_app.API.Project.MVC.Models.Domain;
using mono_app.API.Project.Service.Contexts;
using mono_app.API.Project.Service.Repositories;

namespace mono_app.API.Project.MVC.Project.Service.Repositories
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private IVehicleContext vehicleContext;
        public VehicleMakeRepository(IVehicleContext context)
        {
            vehicleContext = context;
        }

        public async Task<IEnumerable<VehicleMake>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000)
        {
            var vehicleMakes = vehicleContext.VehicleMakes.AsQueryable();


            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    vehicleMakes = vehicleMakes.Where(x => x.Name.Contains(filterQuery));
                }
                else if (filterOn.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
                {
                    vehicleMakes = vehicleMakes.Where(x => x.Abrv.Contains(filterQuery));
                }
            }


            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    vehicleMakes = isAscending ? vehicleMakes.OrderBy(x => x.Name) : vehicleMakes.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
                {
                    vehicleMakes = isAscending ? vehicleMakes.OrderBy(x => x.Abrv) : vehicleMakes.OrderByDescending(x => x.Abrv);
                }
            }

            // Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await vehicleMakes.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<VehicleMake> GetAsync(Guid id)
        {
            return await vehicleContext.VehicleMakes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<VehicleMake> AddAsync(VehicleMake vehicleMake)
        {
            vehicleMake.Id = Guid.NewGuid();
            vehicleContext.VehicleMakes.Add(vehicleMake);
            await vehicleContext.SaveChangesAsync();
            return vehicleMake;
        }

        public async Task<VehicleMake> DeleteAsync(Guid id)
        {
            var vehicleMake = await vehicleContext.VehicleMakes.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleMake == null)
            {
                return null;
            }

            vehicleContext.VehicleMakes.Remove(vehicleMake);
            await vehicleContext.SaveChangesAsync();
            return vehicleMake;
        }

        public async Task<VehicleMake> UpdateAsync(Guid id, VehicleMake vehicleMake)
        {
            var existingVehicleMake = await vehicleContext.VehicleMakes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingVehicleMake == null)
            {
                return null;
            }

            existingVehicleMake.Name = vehicleMake.Name;
            existingVehicleMake.Abrv = vehicleMake.Abrv;

            await vehicleContext.SaveChangesAsync();

            return existingVehicleMake;
        }
    }
}
