using HotelierProject.DTO.Concrete.StaffDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Abstract;

public interface IStaffService : IGenericService<ResultStaffDto,CreateStaffDto,UpdateStaffDto>
{
}
