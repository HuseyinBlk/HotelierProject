using HotelierProject.Business.Abstract;
using HotelierProject.DTO.Concrete.SubscribeDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController(ISubscribeService subscribeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var values = await subscribeService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var value = await subscribeService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscribeDto createSubscribeDto)
        {
            await subscribeService.CreateAsync(createSubscribeDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubscribeDto updateSubscribeDto)
        {
            await subscribeService.UpdateAsync(updateSubscribeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await subscribeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
