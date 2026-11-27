using HotelierProject.Business.Abstract;
using HotelierProject.DTO.Concrete.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialController(ITestimonialService testimonialService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await testimonialService.GetAllAsync();
        return Ok(values);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await testimonialService.GetByIdAsync(id);
        if (value is null)
            return NotFound("Referans bulunamadı.");

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
    {
        await testimonialService.CreateAsync(createTestimonialDto);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
    {
        await testimonialService.UpdateAsync(updateTestimonialDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await testimonialService.DeleteAsync(id);
        return NoContent();
    }
}
