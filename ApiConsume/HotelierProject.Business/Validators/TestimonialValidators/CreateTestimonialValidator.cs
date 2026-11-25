using FluentValidation;
using HotelierProject.DTO.Concrete.TestimonialDtos;

namespace HotelierProject.Business.Validators.TestimonialValidators;

public class CreateTestimonialValidator : AbstractValidator<CreateTestimonialDto>
{
    public CreateTestimonialValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Ad Soyad alanı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Ad Soyad en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Ad Soyad en fazla 50 karakter olabilir.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Unvan alanı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Unvan en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Unvan en fazla 50 karakter olabilir.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Referans yorum açıklaması boş bırakılamaz.")
            .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir.");

        RuleFor(x => x.ProfilImage)
            .NotEmpty().WithMessage("Profil görseli boş bırakılamaz.");
    }
}
