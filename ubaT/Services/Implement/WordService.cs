using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ubaT.DAL;
using ubaT.DTOs.Words;
using ubaT.Entities;
using ubaT.Exceptions.Word;
using ubaT.Services.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ubaT.Services.Implement
{
    public class WordService(ubaTDbContext _context,IMapper _mapper) : IWordService
    {
        
        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var datas= await _context.Words.ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(datas);
        }

        public async Task<WordGetDto> GetByTextAsync(string? text)
        {
            var entity = await  _context.Words.FirstOrDefaultAsync(x=>x.Text==text);
            if (await _context.Words.AnyAsync(x => x.Text == entity.Text))
            {
              return _mapper.Map<WordGetDto>(entity);
              
            }
            else
            {
                throw new WordExistException($"{text}  uygun soz tapilmadi,zehmet olmasa duzgun soz daxil edin ");
            }
        }
        public async Task CreateAsync(WordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(x => x.Text == dto.Text))
                throw new WordExistException();
            await _context.Words.AddAsync(_mapper.Map<Word>(dto));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WordUpdateDto dto, string text)
        {
            var data= await _context.Words.FindAsync(text);
            if (await _context.Words.AnyAsync(x => x.Text == data.Text))
            {
            _context.Words.Update(data);
            }
            else
            {
                throw new WordExistException($"{text}  uygun soz tapilmadi,zehmet olmasa duzgun soz daxil edin ");
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string text)
        {
            var entity = await _context.Words.FindAsync(text);
            if (await _context.Words.AnyAsync(x => x.Text == entity.Text))
            {
                _context.Words.Remove(entity);
            }
            else
            {
                throw new WordExistException($"{text}  uygun soz tapilmadi,zehmet olmasa duzgun soz daxil edin ");
            }
             await _context.SaveChangesAsync();
        }

    }
}
