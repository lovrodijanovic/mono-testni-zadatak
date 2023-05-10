namespace mono_app.API.Project.MVC.Models.DTO
{
    public class VehicleModelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }

        public VehicleMakeDTO VehicleMake { get; set; }
    }
}
