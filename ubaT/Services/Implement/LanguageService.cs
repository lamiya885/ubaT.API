using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ubaT.DAL;
using ubaT.DTOs.Languages;
using ubaT.Entities;
using ubaT.Exceptions.Language;
using ubaT.Services.Abstracts;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ubaT.Services.Implement
{
    public class LanguageService(ubaTDbContext _context,IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync(); 
         
        }
     
        public async Task UpdateAsync (LanguageUpdateDto dto,string code )
        {
             var entity=await _context.Languages.FindAsync(code);
            if (await _context.Languages.AnyAsync(x => x.Code == entity.Code))
            {
            _context.Languages.Update(_mapper.Map<Language>(dto));
            }
            else
            {
                throw new LanguageExistException($"{code} koduna uygun kod tapilmadi,zehmet olmasa duzgun kod daxil edin ");
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync( string code)
        {
            var entity = await _context.Languages.FindAsync(code);
            if(await _context.Languages.AnyAsync(x=>x.Code==entity.Code))
            {
             _context.Languages.Remove(entity);
            }
            else
            {
                throw new LanguageExistException($"{code} koduna uygun kod tapilmadi,zehmet olmasa duzgun kod daxil edin ");
            }
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
          var datas=  await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);
        }

        public async Task<LanguageGetDto?> GetByCodeAsync(string? code)
        {

            var entity = await _context.Languages.FirstOrDefaultAsync(x=>x.Code==code);
            if (await _context.Languages.AnyAsync(x => x.Code == entity.Code))
            {
                return _mapper.Map<LanguageGetDto>(entity);

            }
            else
            {
                throw new LanguageExistException($"{code} koduna uygun kod tapilmadi,zehmet olmasa duzgun kod daxil edin ");
            }
            return _mapper.Map<LanguageGetDto>(entity);

          
        }
    }
}
