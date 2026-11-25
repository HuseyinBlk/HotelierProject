using HotelierProject.DTO.Abstract;

namespace HotelierProject.DTO.Concrete.TestimonialDtos;

public class ResultTestimonialDto : IBaseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ProfilImage { get; set; }
}
