using HotelierProject.DTO.Abstract;

namespace HotelierProject.DTO.Concrete.TestimonialDtos;

public class UpdateTestimonialDto : IBaseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ProfilImage { get; set; }
}
