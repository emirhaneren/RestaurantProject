using DtoLayer.MenuTableDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.MenuTableValidations
{
    public class CreateMenuTableValidation : AbstractValidator<CreateMenuTableDto>
    {
        public CreateMenuTableValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Masa ismi boş olamaz !");
        }
    }
}
