using FluentValidation;
using SignalR.DtoLayer.MenuTableDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.MenuTableValidators
{
    public class CreateMenuTableValidator : AbstractValidator<CreateMenuTableDto>
    {
        public CreateMenuTableValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Masa adı boş bırakılamaz.")
                .NotNull().WithMessage("Masa adı zorunludur.")
                .MinimumLength(2).WithMessage("Masa adı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Masa adı en fazla 50 karakter olabilir.");
        }
    }
}
