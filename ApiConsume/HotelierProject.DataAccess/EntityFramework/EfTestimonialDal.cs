using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.Concrete;
using HotelierProject.Entity.Concrete;

namespace HotelierProject.DataAccess.EntityFramework;

public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
{
    public EfTestimonialDal(AppDbContext context) : base(context)
    {
    }
}
