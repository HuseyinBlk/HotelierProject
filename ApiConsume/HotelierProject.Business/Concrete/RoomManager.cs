using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class RoomManager : GenericManager<Room>, IRoomService
{
    public RoomManager(IRoomDal roomDal, IUnitOfWork unitOfWork) : base(roomDal, unitOfWork)
    {
    }
}
