using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Concrete.SubscribeDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class SubscribeManager : GenericManager<Subscribe, ResultSubscribeDto, CreateSubscribeDto, UpdateSubscribeDto>, ISubscribeService
{
    public SubscribeManager(ISubscribeDal subscribeDal, IUnitOfWork unitOfWork) : base(subscribeDal, unitOfWork)
    {
    }
}