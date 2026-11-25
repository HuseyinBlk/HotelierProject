using HotelierProject.DTO.Abstract;

namespace HotelierProject.DTO.Concrete.RoomDtos;

public class UpdateRoomDto : IBaseDto
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public string RoomCoverImage { get; set; }
    public int Price { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string BedCount { get; set; }
    public string BathCount { get; set; }
    public string Wifi { get; set; }
}