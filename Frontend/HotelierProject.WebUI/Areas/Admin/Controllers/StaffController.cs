using System.Net.Http.Headers;
using System.Text.Json;
using HotelierProject.WebUI.Models.Staff;
using HotelierProject.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class StaffController(IStaffApiService apiService, IHttpClientFactory httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await apiService.GetAllAsync();
        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateStaffViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.Photo != null && model.Photo.Length > 0)
        {
            var uploadedPath = await UploadFileToApiAsync(model.Photo, "staff");
            if (!string.IsNullOrEmpty(uploadedPath))
            {
                model.ImageUrl = uploadedPath;
            }
        }

        var result = await apiService.CreateAsync(model);

        if (!result.IsSuccess)
        {
            result.AddToModelState(ModelState);
            return View(model);
        }
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await apiService.GetByIdForUpdateAsync(id);
        if (result is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateStaffViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.Photo != null && model.Photo.Length > 0)
        {
            var uploadedPath = await UploadFileToApiAsync(model.Photo, "staff");
            if (!string.IsNullOrEmpty(uploadedPath))
            {
                model.ImageUrl = uploadedPath;
            }
        }

        var result = await apiService.UpdateAsync(model);

        if (!result.IsSuccess)
        {
            result.AddToModelState(ModelState);
            return View(model);
        }
        
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await apiService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task<string?> UploadFileToApiAsync(IFormFile file, string folder)
    {
        try
        {
            var client = httpClientFactory.CreateClient("HotelierApiClient");
            using var content = new MultipartFormDataContent();
        
            await using var stream = file.OpenReadStream();
            using var streamContent = new StreamContent(stream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            content.Add(streamContent, "file", file.FileName);

            var response = await client.PostAsync($"files/upload?folder={folder}", content);
        
            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("Photo", $"Fotoğraf yüklenemedi: {errorBody}");
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseContent);
        
            return doc.RootElement.TryGetProperty("filePath", out var pathElement) 
                ? pathElement.GetString() 
                : null;
        }
        catch (HttpRequestException ex)
        {
            ModelState.AddModelError("Photo", $"Dosya sunucusuna ulaşılamadı: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Photo", $"Beklenmeyen bir hata oluştu: {ex.Message}");
            return null;
        }
    }
}