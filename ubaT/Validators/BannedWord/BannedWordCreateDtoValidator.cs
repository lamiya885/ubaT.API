using FluentValidation;
using ubaT.DTOs.BannedWords;

namespace ubaT.Validators.BannedWord
{
    public class BannedWordCreateDtoValidator:AbstractValidator<BannedWordCreateDto>
    {
        public BannedWordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                 .NotEmpty()
                 .WithMessage("Qadagan edilmis sozun  metni bos ola bilmez")
                 .NotNull()
                 .WithMessage("Qadagan edilmis sozun metni null ola bilmez")
                 .MinimumLength(2)
                 .WithMessage("Qadagan edilmis sozun metninin uzunlugu 2-den az ola bilmez")
                 .MaximumLength(64)
                 .WithMessage("Qadagan edilmis sozun  metninin uzunlugu 64-den cox ola bilmez")
                 .Matches("^[A-Za-z]{2,63}$");
            RuleFor(x => x.WordText)
                 .NotEmpty()
                 .WithMessage("Sozun  metni bos ola bilmez")
                 .NotNull()
                 .WithMessage("Sozun metni null ola bilmez")
                 .MinimumLength(2)
                 .WithMessage("Sozun metninin uzunlugu 2-den az ola bilmez")
                 .MaximumLength(64)
                 .WithMessage("Sozun  metninin uzunlugu 64-den cox ola bilmez")
                 .Matches("^[A-Za-z]{2,63}$");

        }
    }
}
