using AutoMapper;
using mono_app.API.Project.MVC.Models.Domain;
using mono_app.API.Project.MVC.Models.DTO;

namespace mono_app.API.Project.MVC.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<VehicleMake, VehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
            CreateMap<AddVehicleMakeRequestDTO, VehicleMake>().ReverseMap();
            CreateMap<UpdateVehicleMakeRequestDTO, VehicleMake>().ReverseMap();
            CreateMap<AddVehicleModelRequestDTO, VehicleModel>().ReverseMap();
            CreateMap<UpdateVehicleModelRequestDTO, VehicleModel>().ReverseMap();
        }
    }
}
