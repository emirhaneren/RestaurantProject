using DtoLayer.SocialMediaDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.SocialMediaValidations
{
    public class CreateSocialMediaValidation:AbstractValidator<CreateSocialMediaDto>
    {
        public CreateSocialMediaValidation()
        { 
            RuleFor(x=>x.Icon).NotEmpty().WithMessage("Icon boş olamaz !");
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x=>x.Url).NotEmpty().WithMessage("URL boş olamaz !");
        }
    }
}
