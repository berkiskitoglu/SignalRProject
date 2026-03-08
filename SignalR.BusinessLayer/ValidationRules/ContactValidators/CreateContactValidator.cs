using FluentValidation;
using SignalR.DtoLayer.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.ContactValidators
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Konum boş bırakılamaz.")
                .NotNull().WithMessage("Konum zorunludur.")
                .MaximumLength(200).WithMessage("Konum en fazla 200 karakter olabilir.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon boş bırakılamaz.")
                .NotNull().WithMessage("Telefon zorunludur.")
                .Matches(@"^(\+90|0)?5\d{9}$").WithMessage("Geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Mail boş bırakılamaz.")
                .NotNull().WithMessage("Mail zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.")
                .MaximumLength(100).WithMessage("Mail en fazla 100 karakter olabilir.");

            RuleFor(x => x.FooterTitle)
                .NotEmpty().WithMessage("Footer başlığı boş bırakılamaz.")
                .NotNull().WithMessage("Footer başlığı zorunludur.")
                .MaximumLength(100).WithMessage("Footer başlığı en fazla 100 karakter olabilir.");

            RuleFor(x => x.FooterDescription)
                .NotEmpty().WithMessage("Footer açıklaması boş bırakılamaz.")
                .NotNull().WithMessage("Footer açıklaması zorunludur.")
                .MaximumLength(500).WithMessage("Footer açıklaması en fazla 500 karakter olabilir.");

            RuleFor(x => x.OpenDays)
                .NotEmpty().WithMessage("Açık günler boş bırakılamaz.")
                .NotNull().WithMessage("Açık günler zorunludur.")
                .MaximumLength(100).WithMessage("Açık günler en fazla 100 karakter olabilir.");

            RuleFor(x => x.OpenDaysDescription)
                .NotEmpty().WithMessage("Açık günler açıklaması boş bırakılamaz.")
                .NotNull().WithMessage("Açık günler açıklaması zorunludur.")
                .MaximumLength(200).WithMessage("Açık günler açıklaması en fazla 200 karakter olabilir.");

            RuleFor(x => x.OpenHours)
                .NotEmpty().WithMessage("Çalışma saatleri boş bırakılamaz.")
                .NotNull().WithMessage("Çalışma saatleri zorunludur.")
                .MaximumLength(100).WithMessage("Çalışma saatleri en fazla 100 karakter olabilir.");
        }
    }
}
