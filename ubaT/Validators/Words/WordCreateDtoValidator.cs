using FluentValidation;
using ubaT.DTOs.Words;

namespace ubaT.Validators.Words
{
    public class WordCreateDtoValidator:AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                    .NotEmpty()
                    .WithMessage("Sozun metni bos ola bilmez")
                    .NotNull()
                    .WithMessage("Sozun metni null ola bilmez")
                    .MinimumLength(2)
                    .WithMessage("Sozun metninin uzunlugu 2-den az ola bilmez")
                    .MaximumLength(64)
                    .WithMessage("Sozun  metninin uzunlugu 64-den cox ola bilmez")
                    .Matches("^[A-Za-z]{2,63}$");
            RuleFor(x => x.LangCode)
                   .NotEmpty()
                   .WithMessage("Kod boş ola bilməz ")
                   .NotNull()
                   .WithMessage("Kod null ola bilməz ")
                   .Length(2)
                   .WithMessage("Kod uzunluğu 2-dən az ve ya cox ola bilməz ");
        }

    }
}
