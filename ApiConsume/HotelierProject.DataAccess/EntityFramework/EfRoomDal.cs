using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.Concrete;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.DataAccess.EntityFramework;

public class EfRoomDal : GenericRepository<Room>, IRoomDal
{
    public EfRoomDal(AppDbContext context) : base(context)
    {
    }
}
