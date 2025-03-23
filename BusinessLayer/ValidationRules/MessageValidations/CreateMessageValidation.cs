using DtoLayer.MessageDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.MessageValidations
{
    public class CreateMessageValidation : AbstractValidator<CreateMessageDto>
    {
        public CreateMessageValidation()
        {
            RuleFor(x=>x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş olamaz !");
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("İsim ve soyisim boş olamaz !");
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail boş olamaz !");
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Telefon boş olamaz !");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu boş olamaz !");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz !");

            RuleFor(x => x.NameSurname).MinimumLength(5).WithMessage("İsim ve soyisim en az 5 karakter olmalıdır !");
            RuleFor(x => x.NameSurname).MaximumLength(100).WithMessage("İsim ve soyisim en fazla 100 karakter olmalıdır !");

            RuleFor(x => x.PhoneNumber).MinimumLength(7).WithMessage("Lütfen geçerli bir telefon numarası giriniz !");
        }
    }
}
