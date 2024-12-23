using ubaT.DTOs.BannedWords;
using ubaT.DTOs.Words;

namespace ubaT.Services.Abstracts
{
    public interface IBannedWordService
    {
        Task CreateAsync(BannedWordCreateDto dto);
        Task UpdateAsync(BannedWordUpdateDto dto, string text);
        Task DeleteAsync(string text);
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
       Task<BannedWordGetDto> GetByTextAsync(string text);
    }
}
