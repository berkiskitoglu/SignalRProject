using FluentValidation;
using SignalR.DtoLayer.BookingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidators
{
    public class UpdateBookingValidator : AbstractValidator<UpdateBookingDto>
    {
        public UpdateBookingValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad Soyad boş bırakılamaz.")
                .NotNull().WithMessage("Ad Soyad zorunludur.")
                .MinimumLength(3).WithMessage("Ad Soyad en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon boş bırakılamaz.")
                .NotNull().WithMessage("Telefon zorunludur.")
                .Matches(@"^(\+90|0)?5\d{9}$").WithMessage("Geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Mail boş bırakılamaz.")
                .NotNull().WithMessage("Mail zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.")
                .MaximumLength(100).WithMessage("Mail en fazla 100 karakter olabilir.");

            RuleFor(x => x.PersonCount)
                .GreaterThan(0).WithMessage("Kişi sayısı 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(50).WithMessage("Kişi sayısı en fazla 50 olabilir.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Rezervasyon tarihi boş bırakılamaz.")
                .GreaterThan(DateTime.Now).WithMessage("Rezervasyon tarihi bugünden ileri bir tarih olmalıdır.");
        }
    }
}
