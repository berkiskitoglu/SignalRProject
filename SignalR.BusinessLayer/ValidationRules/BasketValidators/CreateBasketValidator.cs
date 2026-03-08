using FluentValidation;
using SignalR.BusinessLayer.ValidationRules.BasketProductValidators;
using SignalR.DtoLayer.BasketDtos;

namespace SignalR.BusinessLayer.ValidationRules.BasketValidators
{
    public class CreateBasketValidator : AbstractValidator<CreateBasketDto>
    {
        public CreateBasketValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Durum boş bırakılamaz.")
                .NotNull().WithMessage("Durum zorunludur.")
                .MaximumLength(50).WithMessage("Durum en fazla 50 karakter olabilir.");

            RuleFor(x => x.MenuTableID)
                .GreaterThan(0).WithMessage("Masa ID geçerli olmalıdır.");

            RuleFor(x => x.Products)
                .NotNull().WithMessage("Ürün listesi zorunludur.")
                .NotEmpty().WithMessage("En az bir ürün eklenmelidir.");

            RuleForEach(x => x.Products)
                .SetValidator(new CreateBasketProductValidator());
        }
    }
}
