using ubaT.DTOs.BannedWords;
using ubaT.DTOs.Words;

namespace ubaT.Services.Abstracts
{
    public interface IBannedWordService
    {
        Task<int> CreateAsync(BannedWordCreateDto dto);
        Task<int> UpdateAsync(BannedWordUpdateDto dto, string text);
        Task<int> DeleteAsync(string text);
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
       Task<BannedWordGetDto> GetByTextAsync(string text);
    }
}
