using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutFooterComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}