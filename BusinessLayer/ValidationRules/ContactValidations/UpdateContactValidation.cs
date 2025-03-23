using DtoLayer.ContactDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ContactValidations
{
    public class UpdateContactValidation:AbstractValidator<UpdateContactDto>
    {
        public UpdateContactValidation()
        {
            RuleFor(x => x.FooterDescription).NotEmpty().WithMessage("Footer açıklaması boş olamaz !");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş olamaz !");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Konum boş olamaz !");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş olamaz !");
        }
    }
}
