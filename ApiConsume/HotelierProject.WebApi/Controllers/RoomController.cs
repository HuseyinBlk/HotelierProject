using HotelierProject.Business.Abstract;
using HotelierProject.DTO.Concrete.RoomDtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomService roomService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await roomService.GetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await  roomService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomDto createRoomDto)
        {
            await roomService.CreateAsync(createRoomDto);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoomDto updateRoomDto)
        {
            await  roomService.UpdateAsync(updateRoomDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await roomService.DeleteAsync(id);
            return NoContent();
        }
    }
}
