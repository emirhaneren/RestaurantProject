using DtoLayer.DiscountDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.DiscountValidations
{
    public class UpdateDiscountValdiation : AbstractValidator<UpdateDiscountDto>
    {
        public UpdateDiscountValdiation()
        {
            RuleFor(x=>x.DiscountTitle).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x=>x.Amount).NotEmpty().WithMessage("Oran boş olamaz !");
        }
    }
}
