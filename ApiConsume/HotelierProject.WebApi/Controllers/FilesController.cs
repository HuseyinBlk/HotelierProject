using HotelierProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController(IFileService fileService) : ControllerBase
{
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload(IFormFile? file, [FromQuery] string folder = "general")
    {
        if (file is null)
        {
            return BadRequest(new { message = "Lütfen bir dosya seçiniz." });
        }

        try
        {
            var relativePath = await fileService.UploadAsync(file, folder);
            return Ok(new { filePath = relativePath });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Dosya yüklenirken bir hata oluştu.", detail = ex.Message });
        }
    }
}