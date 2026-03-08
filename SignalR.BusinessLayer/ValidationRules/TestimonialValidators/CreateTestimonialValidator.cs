using FluentValidation;
using SignalR.DtoLayer.TestimonialDtos;

namespace SignalR.BusinessLayer.ValidationRules.TestimonialValidators
{
    public class CreateTestimonialValidator : AbstractValidator<CreateTestimonialDto>
    {
        public CreateTestimonialValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad boş bırakılamaz.")
                .NotNull().WithMessage("Ad zorunludur.")
                .MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Unvan boş bırakılamaz.")
                .NotNull().WithMessage("Unvan zorunludur.")
                .MinimumLength(2).WithMessage("Unvan en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Unvan en fazla 100 karakter olabilir.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum boş bırakılamaz.")
                .NotNull().WithMessage("Yorum zorunludur.")
                .MinimumLength(10).WithMessage("Yorum en az 10 karakter olmalıdır.")
                .MaximumLength(1000).WithMessage("Yorum en fazla 1000 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim URL boş bırakılamaz.")
                .NotNull().WithMessage("Resim URL zorunludur.")
                .MaximumLength(500).WithMessage("Resim URL en fazla 500 karakter olabilir.");
        }
    }
}