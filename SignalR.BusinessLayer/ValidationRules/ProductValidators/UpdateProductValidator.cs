using FluentValidation;
using SignalR.DtoLayer.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.ProductValidators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .NotNull().WithMessage("Ürün adı zorunludur.")
                .MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .NotNull().WithMessage("Açıklama zorunludur.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(99999).WithMessage("Fiyat en fazla 99.999 olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim URL boş bırakılamaz.")
                .NotNull().WithMessage("Resim URL zorunludur.")
                .MaximumLength(500).WithMessage("Resim URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.CategoryID)
                .GreaterThan(0).WithMessage("Kategori seçimi zorunludur.");
        }
    }
}
