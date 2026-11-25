using HotelierProject.Entity.Common;

namespace HotelierProject.Entity.Concrete;

public class Testimonial : BaseEntity
{
    public string FullName { get; set; }
    public string Title {get; set;}
    public string Description { get; set; }
    public string ProfilImage { get; set; }
}