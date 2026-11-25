using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Concrete.RoomDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class RoomManager : GenericManager<Room, ResultRoomDto, CreateRoomDto, UpdateRoomDto>, IRoomService
{
    public RoomManager(IRoomDal roomDal, IUnitOfWork unitOfWork) : base(roomDal, unitOfWork)
    {
    }
}