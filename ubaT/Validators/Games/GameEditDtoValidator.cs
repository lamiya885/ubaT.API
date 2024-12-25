using FluentValidation;
using ubaT.DTOs.Games;

namespace ubaT.Validators.Games
{
    public class GameEditDtoValidator:AbstractValidator<GameEditDto>
    {
        public GameEditDtoValidator()
        {
            RuleFor(x => x.BannedWordCount)
                .NotEmpty()
                .NotNull()
                .Must(x => x > 4)
                .Must(x => x < 6);
            RuleFor(x=>x.FailCount)
                .NotNull()
                .NotEmpty();
            RuleFor(x=>x.SkipCount)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Time)
                .NotNull()
                .NotEmpty();
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
