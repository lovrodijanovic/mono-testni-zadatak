namespace mono_app.API.Models.Domain
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }



        // Navigation properties
        public VehicleMake VehicleMake { get; set; }
    }
}
