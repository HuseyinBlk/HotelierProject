using FluentValidation;
using HotelierProject.DTO.Concrete.SubscribeDtos;

namespace HotelierProject.Business.Validators.SubscribeValidators;

public class CreateSubscribeValidator : AbstractValidator<CreateSubscribeDto>
{
    public CreateSubscribeValidator()
    {
        RuleFor(x => x.MailAddress)
            .NotEmpty().WithMessage("E-posta adresi boş bırakılamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi formatı giriniz.")
            .MaximumLength(150).WithMessage("E-posta adresi en fazla 150 karakter olabilir.");
    }
}
