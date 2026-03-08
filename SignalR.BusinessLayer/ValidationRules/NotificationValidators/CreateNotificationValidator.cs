using FluentValidation;
using SignalR.DtoLayer.NotificationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.NotificationValidators
{
    public class CreateNotificationValidator : AbstractValidator<CreateNotificationDto>
    {
        public CreateNotificationValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Bildirim tipi boş bırakılamaz.")
                .NotNull().WithMessage("Bildirim tipi zorunludur.")
                .MaximumLength(50).WithMessage("Bildirim tipi en fazla 50 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .NotNull().WithMessage("Açıklama zorunludur.")
                .MinimumLength(5).WithMessage("Açıklama en az 5 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("İkon boş bırakılamaz.")
                .NotNull().WithMessage("İkon zorunludur.")
                .MaximumLength(100).WithMessage("İkon en fazla 100 karakter olabilir.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih boş bırakılamaz.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Tarih geçerli olmalıdır.");
        }
    }
}
