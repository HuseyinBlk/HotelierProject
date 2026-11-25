using HotelierProject.DTO.Abstract;

namespace HotelierProject.DTO.Concrete.SubscribeDtos;

public class ResultSubscribeDto : IBaseDto
{
    public int Id { get; set; }
    public string MailAddress { get; set; }
}
