using HotelierProject.Business.Abstract;
using HotelierProject.DTO.Concrete.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialController : ControllerBase
{
    private readonly ITestimonialService _testimonialService;

    public TestimonialController(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _testimonialService.GetAllAsync();
        return Ok(values);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _testimonialService.GetByIdAsync(id);
        if (value is null)
            return NotFound("Referans bulunamadı.");

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
    {
        await _testimonialService.CreateAsync(createTestimonialDto);
        return Ok("Referans başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
    {
        await _testimonialService.UpdateAsync(updateTestimonialDto);
        return Ok("Referans başarıyla güncellendi.");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _testimonialService.DeleteAsync(id);
        return Ok("Referans başarıyla silindi.");
    }
}