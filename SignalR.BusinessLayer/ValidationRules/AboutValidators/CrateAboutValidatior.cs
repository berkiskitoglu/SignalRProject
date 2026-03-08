using FluentValidation;
using SignalR.DtoLayer.AboutDtos;

namespace SignalR.BusinessLayer.ValidationRules.AboutValidators
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
    {
   
        public CreateAboutValidator()
        {
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim URL boş bırakılamaz.")
                .NotNull().WithMessage("Resim URL zorunludur.")
                .MaximumLength(500).WithMessage("Resim URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
                .NotNull().WithMessage("Başlık zorunludur.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .NotNull().WithMessage("Açıklama zorunludur.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");
        }
    }
}
