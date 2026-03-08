using FluentValidation;
using SignalR.DtoLayer.DiscountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.DiscountValidators
{
    public class UpdateDiscountValidator : AbstractValidator<UpdateDiscountDto>
    {
        public UpdateDiscountValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
                .NotNull().WithMessage("Başlık zorunludur.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("İndirim miktarı 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(100).WithMessage("İndirim miktarı en fazla 100 olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .NotNull().WithMessage("Açıklama zorunludur.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim URL boş bırakılamaz.")
                .NotNull().WithMessage("Resim URL zorunludur.")
                .MaximumLength(500).WithMessage("Resim URL en fazla 500 karakter olabilir.");
        }
    }
}
