using FluentValidation;
using SignalR.DtoLayer.SocialMediaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.SocialMediaValidators
{
    public class CreateSocialMediaValidator : AbstractValidator<CreateSocialMediaDto>
    {
        public CreateSocialMediaValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
                .NotNull().WithMessage("Başlık zorunludur.")
                .MinimumLength(2).WithMessage("Başlık en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olabilir.");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("URL boş bırakılamaz.")
                .NotNull().WithMessage("URL zorunludur.")
                .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _)).WithMessage("Geçerli bir URL giriniz.")
                .MaximumLength(200).WithMessage("URL en fazla 200 karakter olabilir.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("İkon boş bırakılamaz.")
                .NotNull().WithMessage("İkon zorunludur.")
                .MaximumLength(100).WithMessage("İkon en fazla 100 karakter olabilir.");
        }
    }
}
