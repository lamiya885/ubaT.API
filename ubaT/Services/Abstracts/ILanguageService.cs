using ubaT.DTOs.Languages;

namespace ubaT.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task UpdateAsync(LanguageUpdateDto dto,string code);
        Task DeleteAsync(string code);
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task<LanguageGetDto> GetByCodeAsync(string code);


    }
}
