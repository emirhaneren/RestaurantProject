using DtoLayer.SliderDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.SliderValidations
{
    public class CreateSliderValidation : AbstractValidator<CreateSliderDto>
    {
        public CreateSliderValidation() {
            RuleFor(x => x.Title1).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x => x.Title3).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama boş olamaz !");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama boş olamaz !");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama boş olamaz !");
        }
    }
}
