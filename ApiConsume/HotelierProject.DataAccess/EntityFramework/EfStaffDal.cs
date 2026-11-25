using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.Concrete;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.DataAccess.EntityFramework;

public class EfStaffDal : GenericRepository<Staff>, IStaffDal
{
    public EfStaffDal(AppDbContext context) : base(context)
    {
    }
}
