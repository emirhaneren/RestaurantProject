using DtoLayer.SocialMediaDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.SocialMediaValidations
{
    public class UpdateSocialMediaValidation : AbstractValidator<UpdateSocialMediaDto>
    {
        public UpdateSocialMediaValidation()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon boş olamaz !");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x => x.Url).NotEmpty().WithMessage("URL boş olamaz !");
        }
    }
}
