using FluentValidation;
using ubaT.DTOs.Games;
using ubaT.Entities;

namespace ubaT.Validators.Games
{
    public class GameStatusDtoValidator:AbstractValidator<GameStatusDto>
    {
        public GameStatusDtoValidator()
        {
            RuleFor(x => x.Success);
            RuleFor(x=>x.Fail);
            RuleFor(x => x.Skip);

        }

    }
}
