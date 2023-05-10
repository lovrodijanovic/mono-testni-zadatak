﻿using Microsoft.EntityFrameworkCore;
using mono_app.API.Data;
using mono_app.API.Models.Domain;

namespace mono_app.API.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly CarsDbContext carsDbContext;
        public VehicleModelRepository(CarsDbContext carsDbContext)
        {
            this.carsDbContext = carsDbContext;
        }

        public async Task<VehicleModel> AddAsync(VehicleModel vehicleModel)
        {
            vehicleModel.Id= Guid.NewGuid();
            await carsDbContext.AddAsync(vehicleModel);
            await carsDbContext.SaveChangesAsync();
            return vehicleModel;
        }

        public async Task<VehicleModel> DeleteAsync(Guid id)
        {
            var vehicleModel = await carsDbContext.VehicleModels.FirstOrDefaultAsync(x => x.Id == id);
            if(vehicleModel == null)
            {
                return null;
            }

            carsDbContext.VehicleModels.Remove(vehicleModel);
            await carsDbContext.SaveChangesAsync();
            return vehicleModel;
        }

        public async Task<IEnumerable<VehicleModel>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null,  bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var vehicleModels = carsDbContext.VehicleModels.Include("VehicleMake").AsQueryable();


            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    vehicleModels = vehicleModels.Where(x => x.Name.Contains(filterQuery));
                }
                if (filterOn.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
                {
                    vehicleModels = vehicleModels.Where(x => x.Abrv.Contains(filterQuery));
                }
            }

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    vehicleModels = isAscending ? vehicleModels.OrderBy(x => x.Name) : vehicleModels.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
                {
                    vehicleModels = isAscending ? vehicleModels.OrderBy(x => x.Abrv) : vehicleModels.OrderByDescending(x => x.Abrv);
                }
            }

            // Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await vehicleModels.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<VehicleModel> GetAsync(Guid id)
        {
            return await carsDbContext.VehicleModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<VehicleModel> UpdateAsync(Guid id, VehicleModel vehicleModel)
        {
            var existingVehicleModel = await carsDbContext.VehicleModels.FirstOrDefaultAsync(x => x.Id == id);

            if(existingVehicleModel == null)
            {
                return null;
            }

            existingVehicleModel.Name = vehicleModel.Name;
            existingVehicleModel.Abrv = vehicleModel.Abrv;

            await carsDbContext.SaveChangesAsync();

            return existingVehicleModel;
        }
    }
}
