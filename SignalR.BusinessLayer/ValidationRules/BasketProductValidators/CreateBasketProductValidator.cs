using FluentValidation;
using SignalR.DtoLayer.BasketProductDtos;

namespace SignalR.BusinessLayer.ValidationRules.BasketProductValidators
{
    public class CreateBasketProductValidator : AbstractValidator<CreateBasketProductDto>
    {
        public CreateBasketProductValidator()
        {
            RuleFor(x => x.BasketID)
                .GreaterThan(0).WithMessage("Sepet ID geçerli olmalıdır.");

            RuleFor(x => x.ProductID)
                .GreaterThan(0).WithMessage("Ürün ID geçerli olmalıdır.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(100).WithMessage("Miktar en fazla 100 olabilir.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Toplam fiyat 0'dan büyük olmalıdır.");
        }
    }
}
