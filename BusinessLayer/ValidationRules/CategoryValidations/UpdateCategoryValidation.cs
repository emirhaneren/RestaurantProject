using DtoLayer.CategoryDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.CategoryValidations
{
    public class UpdateCategoryValidation:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş olamaz !");
        }
    }
}
