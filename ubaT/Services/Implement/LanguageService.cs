using Microsoft.EntityFrameworkCore;
using ubaT.DAL;
using ubaT.DTOs.Languages;
using ubaT.Services.Abstracts;

namespace ubaT.Services.Implement
{
    public class LanguageService(ubaTDbContext _context) : ILanguageService
    {
        public async Task CreatedAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Entities.Languages { 
                Code=dto.Code,
                Name=dto.Name,
                Icon=dto.Icon
            });

            await _context.SaveChangesAsync(); 
         
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguageGetDto
            {
                Code = x.Code,
                Name = x.Name,
                Icon = x.Icon
            }).ToListAsync();
        }
    }
}
