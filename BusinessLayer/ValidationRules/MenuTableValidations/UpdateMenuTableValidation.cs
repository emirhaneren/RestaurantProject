using DtoLayer.MenuTableDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.MenuTableValidations
{
    public class UpdateMenuTableValidation : AbstractValidator<UpdateMenuTableDto>
    {
        public UpdateMenuTableValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Masa ismi boş olamaz !");
        }
    }
}
