using System.ComponentModel.DataAnnotations;

namespace mono_app.API.Project.MVC.Models.DTO
{
    public class UpdateVehicleMakeRequestDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name has to be a minimum 1 character long")]
        [MaxLength(50, ErrorMessage = "Name has to be a maximum 50 character long")]
        public string Name { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Abrv has to be a minimum 1 character long")]
        [MaxLength(50, ErrorMessage = "Abrv has to be a maximum 50 character long")]
        public string Abrv { get; set; }
    }
}
