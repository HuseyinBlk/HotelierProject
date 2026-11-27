using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Concrete.StaffDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class StaffManager(IStaffDal staffDal, IUnitOfWork unitOfWork) 
    : GenericManager<Staff, ResultStaffDto, CreateStaffDto, UpdateStaffDto>(staffDal, unitOfWork), IStaffService;
