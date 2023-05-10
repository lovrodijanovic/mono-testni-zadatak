﻿using Microsoft.EntityFrameworkCore;
using mono_app.API.Project.MVC.Models.Domain;

namespace mono_app.API.Project.Service.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
