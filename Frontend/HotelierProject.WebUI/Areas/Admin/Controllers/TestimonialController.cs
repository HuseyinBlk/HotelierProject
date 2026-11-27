using HotelierProject.WebUI.Models.Testimonial;
using HotelierProject.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class TestimonialController(ITestimonialApiService apiService) : Controller
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
    public async Task<IActionResult> Create(CreateTestimonialViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
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
    public async Task<IActionResult> Edit(UpdateTestimonialViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
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
}