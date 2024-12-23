using FluentValidation;
using ubaT.DTOs.Languages;

namespace ubaT.Validators.Languages
{
    public class LanguagesCreateDtoValidator:AbstractValidator<LanguageCreateDto>
    {
        public LanguagesCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                 .NotEmpty()
                   .WithMessage("Kod boş ola bilməz ")
                 .NotNull()
                   .WithMessage("Kod null ola bilməz ")
                 .Length(2)
                   .WithMessage("Kod uzunluğu 2-dən az ve ya cox ola bilməz ");
            RuleFor(x=>x.Name)
                .MinimumLength(3)
                  .WithMessage("Ad uzunluğu 3-dən az ola bilməz ")
                .MaximumLength(32)
                  .WithMessage("Ad uzunluğu 32-dən çox ola bilməz ");
           RuleFor(x => x.IconUrl)
               .MaximumLength(128)
                 .WithMessage("Ad uzunluğu 128-dən çox ola bilməz ")
               .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                 .WithMessage("Url link olmalıdır");
        }

    }
}
