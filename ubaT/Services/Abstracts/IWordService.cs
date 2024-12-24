using ubaT.DTOs.Words;

namespace ubaT.Services.Abstracts
{
    public interface IWordService
    {
        Task<int> CreateAsync(WordCreateDto dto);
        Task<int> UpdateAsync(WordUpdateDto dto, string text);
        Task<int> DeleteAsync(string text);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task<WordGetDto> GetByTextAsync(string text);
        
            
    }
}
