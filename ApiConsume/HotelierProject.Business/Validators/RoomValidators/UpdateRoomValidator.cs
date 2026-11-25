using FluentValidation;
using HotelierProject.DTO.Concrete.RoomDtos;

namespace HotelierProject.Business.Validators.RoomValidators;

public class UpdateRoomValidator : AbstractValidator<UpdateRoomDto>
{
    public UpdateRoomValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Güncellenecek oda için geçerli bir ID girilmelidir.");
        
        RuleFor(x => x.RoomNumber)
            .NotEmpty().WithMessage("Oda numarası boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Oda numarası en fazla 50 karakter olabilir.");
        
        RuleFor(x => x.RoomCoverImage)
            .NotEmpty().WithMessage("Oda kapak görseli boş bırakılamaz.");
        
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Oda fiyatı boş bırakılamaz.")
            .GreaterThan(0).WithMessage("Oda fiyatı 0'dan büyük bir değer olmalıdır.");
        
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Oda başlığı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Oda başlığı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Oda başlığı en fazla 100 karakter olabilir.");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Oda açıklaması boş bırakılamaz.")
            .MaximumLength(500).WithMessage("Oda açıklaması en fazla 500 karakter olabilir.");
        
        RuleFor(x => x.BedCount)
            .NotEmpty().WithMessage("Yatak sayısı bilgisi boş bırakılamaz.");
        
        RuleFor(x => x.BathCount)
            .NotEmpty().WithMessage("Banyo sayısı bilgisi boş bırakılamaz.");
        
        RuleFor(x => x.Wifi)
            .NotEmpty().WithMessage("Wifi durumu bilgisi boş bırakılamaz.");
    }
}