using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutScriptComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}