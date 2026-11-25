using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class StaffManager : GenericManager<Staff>, IStaffService
{
    public StaffManager(IStaffDal staffDal, IUnitOfWork unitOfWork) : base(staffDal, unitOfWork)
    {
    }
}
