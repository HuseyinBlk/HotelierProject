using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutPreloaderComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}