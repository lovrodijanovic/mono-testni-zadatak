using Autofac;
using mono_app.API.Project.MVC.Project.Service.Repositories;
using mono_app.API.Project.Service.Contexts;
using mono_app.API.Project.Service.Repositories;

namespace mono_app.API.Project.Service
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleContext>().As<IVehicleContext>();
            builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>();
            builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>();
        }
    }
}
