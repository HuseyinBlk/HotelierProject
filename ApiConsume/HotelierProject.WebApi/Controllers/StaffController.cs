using HotelierProject.Business.Abstract;
using HotelierProject.DTO.Concrete.StaffDtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _staffService.GetAllAsync();
        return Ok(values);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _staffService.GetByIdAsync(id);
        if (value is null)
            return NotFound("Personel bulunamadı.");

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStaffDto createStaffDto)
    {
        await _staffService.CreateAsync(createStaffDto);
        return Ok("Personel başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateStaffDto updateStaffDto)
    {
        await _staffService.UpdateAsync(updateStaffDto);
        return Ok("Personel başarıyla güncellendi.");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _staffService.DeleteAsync(id);
        return Ok("Personel başarıyla silindi.");
    }
}