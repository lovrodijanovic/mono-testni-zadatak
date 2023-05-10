using AutoMapper;
using mono_app.API.Models.Domain;
using mono_app.API.Models.DTO;

namespace mono_app.API.Mappings
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
