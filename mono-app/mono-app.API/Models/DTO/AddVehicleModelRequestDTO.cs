namespace mono_app.API.Models.DTO
{
    public class AddVehicleModelRequestDTO
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }
    }
}
