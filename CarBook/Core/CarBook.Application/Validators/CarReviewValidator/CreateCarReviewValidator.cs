using CarBook.Application.Features.Mediator.Commands.CarReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.CarReviewValidator;

public class CreateCarReviewValidator:AbstractValidator<CreateCarReviewCommand>
{
    public CreateCarReviewValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş göndermeyiniz.").MinimumLength(5).WithMessage("Müşteri adı minimum 5 karakter olmalıdır");
        RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen müşteri yorumunu boş göndermeyiniz.").MinimumLength(50).WithMessage("Müşteri yorumu minimum 50 karakter olmalıdır").MaximumLength(500).WithMessage("Müşteri yorumu max 500 karakter olmalıdır");
        RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puanı boş göndermeyiniz.");
    }
}
