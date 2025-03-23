using DtoLayer.DiscountDto;
using FluentValidation;
namespace BusinessLayer.ValidationRules.DiscountValidations
{
    public class CreateDiscountValidation : AbstractValidator<CreateDiscountDto>
    {
        public CreateDiscountValidation()
        {
            RuleFor(x => x.DiscountTitle).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Oran boş olamaz !");
        }
    }
}
