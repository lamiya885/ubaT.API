using ubaT.DTOs.Words;

namespace ubaT.Services.Abstracts
{
    public interface IWordService
    {
        Task CreateAsync(WordCreateDto dto);
        Task UpdateAsync(WordUpdateDto dto, string text);
        Task DeleteAsync(string text);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task<WordGetDto> GetByTextAsync(string text);
        
            
    }
}
