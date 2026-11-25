using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutSidebarComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}