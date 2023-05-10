using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mono_app.API.Project.MVC.Models.Domain;
using mono_app.API.Project.MVC.Models.DTO;
using mono_app.API.Project.Service.Repositories;

namespace mono_app.API.Project.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelsController : ControllerBase
    {
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IMapper mapper;

        public VehicleModelsController(IVehicleModelRepository vehicleModelRepository, IMapper mapper)
        {
            this.vehicleModelRepository = vehicleModelRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var vehicleModels = await vehicleModelRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            return Ok(mapper.Map<List<VehicleModelDTO>>(vehicleModels));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vehicleModel = await vehicleModelRepository.GetAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleModelDTO>(vehicleModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddVehicleModelRequestDTO addVehicleModelRequestDTO)
        {
            var vehicleModel = mapper.Map<VehicleModel>(addVehicleModelRequestDTO);

            var vehicleModelDTO = await vehicleModelRepository.AddAsync(vehicleModel);

            return CreatedAtAction(nameof(GetById), new { id = vehicleModelDTO.Id }, vehicleModelDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var vehicleModel = await vehicleModelRepository.DeleteAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleModelDTO>(vehicleModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVehicleModelRequestDTO updateVehicleModelRequestDTO)
        {
            var vehicleModel = mapper.Map<VehicleModel>(updateVehicleModelRequestDTO);

            vehicleModel = await vehicleModelRepository.UpdateAsync(id, vehicleModel);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleModelDTO>(vehicleModel));
        }
    }
}
