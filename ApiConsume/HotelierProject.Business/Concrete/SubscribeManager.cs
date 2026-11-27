using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Concrete.SubscribeDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class SubscribeManager(ISubscribeDal subscribeDal, IUnitOfWork unitOfWork) 
    : GenericManager<Subscribe, ResultSubscribeDto, CreateSubscribeDto, UpdateSubscribeDto>(subscribeDal, unitOfWork), ISubscribeService;
