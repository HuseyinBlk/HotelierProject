using FluentValidation;
using HotelierProject.DTO.Concrete.StaffDtos;

namespace HotelierProject.Business.Validators.StaffValidators;

public class UpdateStaffValidator : AbstractValidator<UpdateStaffDto>
{
    public UpdateStaffValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Güncellenecek personel için geçerli bir ID girilmelidir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Personel adı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Personel adı en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Personel unvanı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Personel unvanı en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Personel unvanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.SocialMedia1)
            .NotEmpty().WithMessage("Sosyal medya 1 (Facebook) linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Sosyal medya 1 linki en fazla 250 karakter olabilir.");

        RuleFor(x => x.SocialMedia2)
            .NotEmpty().WithMessage("Sosyal medya 2 (Twitter/X) linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Sosyal medya 2 linki en fazla 250 karakter olabilir.");

        RuleFor(x => x.SocialMedia3)
            .NotEmpty().WithMessage("Sosyal medya 3 (Instagram) linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Sosyal medya 3 linki en fazla 250 karakter olabilir.");
    }
}
