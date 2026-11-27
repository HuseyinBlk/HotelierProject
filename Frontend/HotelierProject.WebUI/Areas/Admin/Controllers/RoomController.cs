using HotelierProject.WebUI.Models.Room;
using HotelierProject.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Areas.Admin.Controllers;

public class RoomController(IRoomApiService apiService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await apiService.GetAllAsync();
        return View(values);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateRoomViewModel model)
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

    public async Task<IActionResult> Edit(int id)
    {
        var value = await apiService.GetByIdForUpdateAsync(id);
        return View(value);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateRoomViewModel model)
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
        await  apiService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}