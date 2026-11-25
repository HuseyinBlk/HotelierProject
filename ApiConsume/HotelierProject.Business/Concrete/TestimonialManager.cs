using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class TestimonialManager : GenericManager<Testimonial>, ITestimonialService
{
    public TestimonialManager(ITestimonialDal testimonialDal, IUnitOfWork unitOfWork) : base(testimonialDal, unitOfWork)
    {
    }
}
