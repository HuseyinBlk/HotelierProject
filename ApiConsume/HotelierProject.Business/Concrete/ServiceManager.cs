using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Concrete.ServiceDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class ServiceManager : GenericManager<Service, ResultServiceDto, CreateServiceDto, UpdateServiceDto>, IServiceService
{
    public ServiceManager(IServiceDal serviceDal, IUnitOfWork unitOfWork) : base(serviceDal, unitOfWork)
    {
    }
}