using Microsoft.AspNetCore.Http;

namespace HotelierProject.Business.Abstract;

public interface IFileService
{
    Task<string> UploadAsync(IFormFile file, string folder = "general");
    void Delete(string? relativePath);
}