using FluentValidation;
using ubaT.DTOs.Games;

namespace ubaT.Validators.Games
{
    public class GameCreateDtoValidator:AbstractValidator<GameCreateDto>
    {
        public GameCreateDtoValidator()
        {
            RuleFor(x => x.BannedWordCount)
                .NotEmpty()
                .NotNull()
                .Must(x => x > 4)
                .Must(x => x < 6);
            RuleFor(x => x.LangCode)
                 .NotEmpty()
                 .WithMessage("Kod boş ola bilməz ")
                 .NotNull()
                 .WithMessage("Kod null ola bilməz ")
                 .Length(2)
                 .WithMessage("Kod uzunluğu 2-dən az ve ya cox ola bilməz ");
            RuleFor(x=>x.FailCount)
                 .NotEmpty()
                 .NotNull();
            RuleFor(x => x.SkipCount)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Time)
                .NotEmpty()
                .NotNull();
        }
    }
}
