using DtoLayer.CategoryDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.CategoryValidations
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidation()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("İsim boş olamaz !");
        }
    }
}
