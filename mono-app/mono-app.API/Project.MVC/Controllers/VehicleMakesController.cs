using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mono_app.API.Project.MVC.Models.Domain;
using mono_app.API.Project.MVC.Models.DTO;
using mono_app.API.Project.Service.Repositories;

namespace mono_app.API.Project.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakesController : ControllerBase
    {
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        private readonly IMapper mapper;

        public VehicleMakesController(IVehicleMakeRepository vehicleMakeRepository, IMapper mapper)
        {
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var vehicleMakes = await vehicleMakeRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            return Ok(mapper.Map<List<VehicleMakeDTO>>(vehicleMakes));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vehicleMake = await vehicleMakeRepository.GetAsync(id);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleMakeDTO>(vehicleMake));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddVehicleMakeRequestDTO addVehicleMakeRequestDTO)
        {
            var vehicleMake = mapper.Map<VehicleMake>(addVehicleMakeRequestDTO);

            vehicleMake = await vehicleMakeRepository.AddAsync(vehicleMake);

            var vehicleMakeDTO = mapper.Map<VehicleMakeDTO>(vehicleMake);

            return CreatedAtAction(nameof(GetById), new { id = vehicleMakeDTO.Id }, vehicleMakeDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var vehicleMake = await vehicleMakeRepository.DeleteAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleMakeDTO>(vehicleMake));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVehicleMakeRequestDTO updateVehicleMakeRequestDTO)
        {
            var vehicleMake = mapper.Map<VehicleMake>(updateVehicleMakeRequestDTO);

            vehicleMake = await vehicleMakeRepository.UpdateAsync(id, vehicleMake);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleMakeDTO>(vehicleMake));
        }
    }
}
