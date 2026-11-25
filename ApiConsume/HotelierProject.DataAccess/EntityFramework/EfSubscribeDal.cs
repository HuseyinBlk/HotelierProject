using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.Concrete;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.DataAccess.EntityFramework;

public class EfSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
{
    public EfSubscribeDal(AppDbContext context) : base(context)
    {
    }
}
