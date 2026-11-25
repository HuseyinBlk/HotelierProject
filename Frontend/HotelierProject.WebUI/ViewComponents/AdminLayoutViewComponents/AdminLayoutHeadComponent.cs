using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutHeadComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}