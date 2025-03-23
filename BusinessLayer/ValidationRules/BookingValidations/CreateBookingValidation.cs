using DtoLayer.BookingDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez !");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez !");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez !");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı boş geçilemez !");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez !");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen isim alanına en az 3 karakter olacak şekilde giriniz !");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Litfen isim alanına en fazla 50 karakter olacak şekilde giriniz !");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz !");

            RuleFor(x => x.Phone).MinimumLength(7).WithMessage("Lütfen geçerli bir telefon numarası giriniz !");
        }
    }
}
