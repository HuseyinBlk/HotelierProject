using FluentValidation;
using HotelierProject.DTO.Concrete.ServiceDtos;

namespace HotelierProject.Business.Validators.ServiceValidators;

public class CreateServiceValidator : AbstractValidator<CreateServiceDto>
{
    public CreateServiceValidator()
    {
        RuleFor(x => x.ServiceIcon)
            .NotEmpty().WithMessage("Hizmet ikonu boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Hizmet ikonu en fazla 100 karakter olabilir.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Hizmet başlığı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Hizmet başlığı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Hizmet başlığı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Hizmet açıklaması boş bırakılamaz.")
            .MaximumLength(500).WithMessage("Hizmet açıklaması en fazla 500 karakter olabilir.");
    }
}
