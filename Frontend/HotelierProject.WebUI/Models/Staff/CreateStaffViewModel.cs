namespace HotelierProject.WebUI.Models.Staff;

public class CreateStaffViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public IFormFile? Photo { get; set; } 
    public string? ImageUrl { get; set; }
    public string? SocialMedia1 { get; set; }
    public string? SocialMedia2 { get; set; }
    public string? SocialMedia3 { get; set; }
}