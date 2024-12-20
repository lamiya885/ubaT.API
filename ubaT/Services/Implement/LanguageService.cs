using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ubaT.DAL;
using ubaT.DTOs.Languages;
using ubaT.Entities;
using ubaT.Services.Abstracts;

namespace ubaT.Services.Implement
{
    public class LanguageService(ubaTDbContext _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Entities.Languages { 
                Code=dto.Code,
                Name=dto.Name,
                Icon=dto.Icon
            });

            await _context.SaveChangesAsync(); 
         
        }
     
        public async Task UpdateAsync (LanguageUpdateDto dto,string code )
        {
             var entity=await _context.Languages.FindAsync(code);

           _context.Languages.Update(new Languages
             {
                 Code=dto.Code,
                 Name=dto.Name,
                 Icon=dto.Icon
             });
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync( string code)
        {
            var entity = await _context.Languages.FindAsync(code);
             _context.Languages.Remove(entity);
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
            await _context.SaveChangesAsync();
        }

        public async Task<LanguageGetDto?> GetByCodeAsync(string? code)
        {

            var entity = await _context.Languages.FirstOrDefaultAsync(x=>x.Code==code);
            return new LanguageGetDto
            {
                Code = entity.Code,
                Name = entity.Name,
                Icon = entity.Icon
            };

            await _context.SaveChangesAsync();

        }
    }
}
