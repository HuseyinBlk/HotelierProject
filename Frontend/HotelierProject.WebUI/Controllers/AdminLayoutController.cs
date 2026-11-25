using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Controllers;

public class AdminLayoutController : Controller
{
    // GET
    public IActionResult _AdminLayout()
    {
        return View();
    }
}