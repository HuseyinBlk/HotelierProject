using HotelierProject.Business.Abstract;
using HotelierProject.DTO.Concrete.StaffDtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController(IStaffService staffService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await staffService.GetAllAsync();
        return Ok(values);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await staffService.GetByIdAsync(id);
        if (value is null)
            return NotFound("Personel bulunamadı.");

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStaffDto createStaffDto)
    {
        await staffService.CreateAsync(createStaffDto);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateStaffDto updateStaffDto)
    {
        await staffService.UpdateAsync(updateStaffDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await staffService.DeleteAsync(id);
        return NoContent();
    }
}
