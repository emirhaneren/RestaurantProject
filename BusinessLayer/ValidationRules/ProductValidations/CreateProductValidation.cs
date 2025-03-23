using DtoLayer.ProductDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ProductValidations
{
    public class CreateProductValidation : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidation()
        {
            RuleFor(x=>x.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz !");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Image URL boş olamaz !");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat boş olamaz !");

            RuleFor(x => x.ProductName).MinimumLength(5).WithMessage("Ürün ismi 5 karakterden az olamaz !");
        }
    }
}
