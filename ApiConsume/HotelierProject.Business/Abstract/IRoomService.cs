using HotelierProject.DTO.Concrete.RoomDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Abstract;

public interface IRoomService : IGenericService<ResultRoomDto,CreateRoomDto,UpdateRoomDto>
{
}
