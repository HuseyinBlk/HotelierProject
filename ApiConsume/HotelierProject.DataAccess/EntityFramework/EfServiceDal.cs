using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.Concrete;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.DataAccess.EntityFramework;

public class EfServiceDal : GenericRepository<Service>, IServiceDal
{
    public EfServiceDal(AppDbContext context) : base(context)
    {
    }
}
