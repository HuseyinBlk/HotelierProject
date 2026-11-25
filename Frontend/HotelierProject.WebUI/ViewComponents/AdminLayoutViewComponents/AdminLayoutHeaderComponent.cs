using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutHeaderComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}