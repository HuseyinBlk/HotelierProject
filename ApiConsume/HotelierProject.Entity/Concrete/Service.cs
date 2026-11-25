using HotelierProject.Entity.Common;

namespace HotelierProject.Entity.Concrete;

public class Service : BaseEntity
{
    public string ServiceIcon { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}