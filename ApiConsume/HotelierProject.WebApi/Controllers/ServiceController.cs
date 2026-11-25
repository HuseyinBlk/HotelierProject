using HotelierProject.Business.Abstract;
using HotelierProject.DTO.Concrete.ServiceDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(IServiceService serviceService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var values = await serviceService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var value = await  serviceService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto createServiceDto)
        {
            await serviceService.CreateAsync(createServiceDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto)
        {
            await serviceService.UpdateAsync(updateServiceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await serviceService.DeleteAsync(id);
            return NoContent();
        }
    }
}
