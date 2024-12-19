using ubaT.DTOs.Languages;

namespace ubaT.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreatedAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
    }
}
