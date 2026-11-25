using HotelierProject.DTO.Concrete.ServiceDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Abstract;

public interface IServiceService : IGenericService<ResultServiceDto,CreateServiceDto,UpdateServiceDto>
{
}
