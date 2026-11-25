using HotelierProject.DTO.Abstract;

namespace HotelierProject.DTO.Concrete.ServiceDtos;

public class UpdateServiceDto : IBaseDto
{
    public int Id { get; set; }
    public string ServiceIcon { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
