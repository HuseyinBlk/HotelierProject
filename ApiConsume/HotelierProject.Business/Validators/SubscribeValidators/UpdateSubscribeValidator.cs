using FluentValidation;
using HotelierProject.DTO.Concrete.SubscribeDtos;

namespace HotelierProject.Business.Validators.SubscribeValidators;

public class UpdateSubscribeValidator : AbstractValidator<UpdateSubscribeDto>
{
    public UpdateSubscribeValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Güncellenecek abonelik için geçerli bir ID girilmelidir.");

        RuleFor(x => x.MailAddress)
            .NotEmpty().WithMessage("E-posta adresi boş bırakılamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi formatı giriniz.")
            .MaximumLength(150).WithMessage("E-posta adresi en fazla 150 karakter olabilir.");
    }
}
