using DtoLayer.TestimonialDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.TestimonialValidations
{
    public class UpdateTestimonialValidation : AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz !");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz !");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image URL boş olamaz !");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum boş olamaz !");
        }
    }
}
