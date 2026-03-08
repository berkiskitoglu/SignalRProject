
using FluentValidation;
using SignalR.DtoLayer.SliderDtos;

namespace SignalR.BusinessLayer.ValidationRules.SliderValidators
{
    public class CreateSliderValidator : AbstractValidator<CreateSliderDto>
    {
        public CreateSliderValidator()
        {
            RuleFor(x => x.Title1)
                .NotEmpty().WithMessage("1. Başlık boş bırakılamaz.")
                .NotNull().WithMessage("1. Başlık zorunludur.")
                .MinimumLength(3).WithMessage("1. Başlık en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("1. Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description1)
                .NotEmpty().WithMessage("1. Açıklama boş bırakılamaz.")
                .NotNull().WithMessage("1. Açıklama zorunludur.")
                .MinimumLength(10).WithMessage("1. Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("1. Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Title2)
                .NotEmpty().WithMessage("2. Başlık boş bırakılamaz.")
                .NotNull().WithMessage("2. Başlık zorunludur.")
                .MinimumLength(3).WithMessage("2. Başlık en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("2. Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description2)
                .NotEmpty().WithMessage("2. Açıklama boş bırakılamaz.")
                .NotNull().WithMessage("2. Açıklama zorunludur.")
                .MinimumLength(10).WithMessage("2. Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("2. Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Title3)
                .NotEmpty().WithMessage("3. Başlık boş bırakılamaz.")
                .NotNull().WithMessage("3. Başlık zorunludur.")
                .MinimumLength(3).WithMessage("3. Başlık en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("3. Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description3)
                .NotEmpty().WithMessage("3. Açıklama boş bırakılamaz.")
                .NotNull().WithMessage("3. Açıklama zorunludur.")
                .MinimumLength(10).WithMessage("3. Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("3. Açıklama en fazla 500 karakter olabilir.");
        }
    }
}

