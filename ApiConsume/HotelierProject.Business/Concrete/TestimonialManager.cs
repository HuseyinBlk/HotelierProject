using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Concrete.TestimonialDtos;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.Business.Concrete;

public class TestimonialManager : GenericManager<Testimonial, ResultTestimonialDto, CreateTestimonialDto, UpdateTestimonialDto>, ITestimonialService
{
    public TestimonialManager(ITestimonialDal testimonialDal, IUnitOfWork unitOfWork) : base(testimonialDal, unitOfWork)
    {
    }
}