using HotelierProject.WebUI.Models.Testimonial;
using HotelierProject.WebUI.Services.Abstract;

namespace HotelierProject.WebUI.Services.Concrete;

public class TestimonialApiService(HttpClient httpClient) 
    : BaseApiService<TestimonialViewModel, CreateTestimonialViewModel, UpdateTestimonialViewModel>(httpClient, "Testimonial"), ITestimonialApiService
{
}