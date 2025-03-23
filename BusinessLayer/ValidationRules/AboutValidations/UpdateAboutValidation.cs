using DtoLayer.AboutDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AboutValidations
{
    public class UpdateAboutValidation:AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz !");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image URL boş olamaz !");
        }
    }
}
