using FluentValidation;
using SignalR.DtoLayer.MessageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.MessageValidators
{
    public class CreateMessageValidator : AbstractValidator<CreateMessageDto>
    {
        public CreateMessageValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad boş bırakılamaz.")
                .NotNull().WithMessage("Ad Soyad zorunludur.")
                .MinimumLength(3).WithMessage("Ad Soyad en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir.");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Mail boş bırakılamaz.")
                .NotNull().WithMessage("Mail zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.")
                .MaximumLength(100).WithMessage("Mail en fazla 100 karakter olabilir.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon boş bırakılamaz.")
                .NotNull().WithMessage("Telefon zorunludur.")
                .Matches(@"^(\+90|0)?5\d{9}$").WithMessage("Geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu boş bırakılamaz.")
                .NotNull().WithMessage("Konu zorunludur.")
                .MinimumLength(3).WithMessage("Konu en az 3 karakter olmalıdır.")
                .MaximumLength(200).WithMessage("Konu en fazla 200 karakter olabilir.");

            RuleFor(x => x.MessageContent)
                .NotEmpty().WithMessage("Mesaj içeriği boş bırakılamaz.")
                .NotNull().WithMessage("Mesaj içeriği zorunludur.")
                .MinimumLength(10).WithMessage("Mesaj içeriği en az 10 karakter olmalıdır.")
                .MaximumLength(1000).WithMessage("Mesaj içeriği en fazla 1000 karakter olabilir.");

            RuleFor(x => x.MessageSendDate)
                .NotEmpty().WithMessage("Gönderim tarihi boş bırakılamaz.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Gönderim tarihi geçerli olmalıdır.");
        }
    }
}
