namespace HotelierProject.WebUI.Models.Service;

public class UpdateServiceViewModel
{
    public int Id { get; set; }
    public string ServiceIcon { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}