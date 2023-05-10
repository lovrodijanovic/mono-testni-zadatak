namespace mono_app.API.Models.DTO
{
    public class UpdateVehicleModelRequestDTO
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }
    }
}
