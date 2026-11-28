using HotelierProject.Business.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HotelierProject.Business.Concrete;

public class LocalFileService(IWebHostEnvironment environment) : IFileService
{
    private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png", ".webp"];
    private const long MaxFileSizeInBytes = 5 * 1024 * 1024; // 5 MB

    public async Task<string> UploadAsync(IFormFile file, string folder = "general")
    {
        ArgumentNullException.ThrowIfNull(file);

        if (file.Length == 0)
        {
            throw new ArgumentException("Yüklenecek dosya boş olamaz.", nameof(file));
        }

        if (file.Length > MaxFileSizeInBytes)
        {
            throw new InvalidOperationException("Dosya boyutu 5 MB sınırını aşamaz.");
        }

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!AllowedExtensions.Contains(extension))
        {
            throw new InvalidOperationException("Yalnızca .jpg, .jpeg, .png ve .webp uzantılı dosyalar yüklenebilir.");
        }

        var webRootPath = environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var targetDirectory = Path.Combine(webRootPath, "uploads", folder);

        if (!Directory.Exists(targetDirectory))
        {
            Directory.CreateDirectory(targetDirectory);
        }

        var uniqueFileName = $"{Guid.NewGuid()}{extension}";
        var fullPath = Path.Combine(targetDirectory, uniqueFileName);

        await using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"uploads/{folder}/{uniqueFileName}";
    }

    public void Delete(string? relativePath)
    {
        if (string.IsNullOrWhiteSpace(relativePath)) return;

        var webRootPath = environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var fullPath = Path.Combine(webRootPath, relativePath.Replace('/', Path.DirectorySeparatorChar));

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }
}