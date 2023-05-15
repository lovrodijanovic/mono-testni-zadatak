using Autofac;
using AutoMapper;
using mono_app.API.Project.MVC.Models.Domain;
using mono_app.API.Project.MVC.Models.DTO;

namespace mono_app.API.Project.MVC.Mappings
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(map =>
            {
                map.CreateMap<VehicleMake, VehicleMakeDTO>().ReverseMap();
                map.CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
                map.CreateMap<AddVehicleMakeRequestDTO, VehicleMake>().ReverseMap();
                map.CreateMap<UpdateVehicleMakeRequestDTO, VehicleMake>().ReverseMap();
                map.CreateMap<AddVehicleModelRequestDTO, VehicleModel>().ReverseMap();
                map.CreateMap<UpdateVehicleModelRequestDTO, VehicleModel>().ReverseMap();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
