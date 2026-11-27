using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Concrete.ServiceDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class ServiceManager(IServiceDal serviceDal, IUnitOfWork unitOfWork) 
    : GenericManager<Service, ResultServiceDto, CreateServiceDto, UpdateServiceDto>(serviceDal, unitOfWork), IServiceService;
