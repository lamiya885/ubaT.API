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
        public async Task<int> CreateAsync(WordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(x => x.Text == dto.Text))
                throw new WordExistException();
            Word word = _mapper.Map<Word>(dto);
            word.BannedWords = dto.BannedWords.Select(x => new BannedWord
            { 
                Text=x
            }).ToList();

            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }

        public async Task<int> UpdateAsync(WordUpdateDto dto, string text)
        {
            var data= await _context.Words.FirstOrDefaultAsync(x=>x.Text==text);
            if (await _context.Words.AnyAsync(x => x.Text == data.Text))
            {
                Word upword=_mapper.Map<Word>(dto);
                upword.BannedWords = dto.BannedWords.Select(x => new BannedWord
                {
                    Text = x
                }).ToList();
            _context.Words.Update(data);
            await _context.SaveChangesAsync();
                return upword.Id;
            }
            else
            {
                throw new WordExistException($"{text}  uygun soz tapilmadi,zehmet olmasa duzgun soz daxil edin ");
            }
        }
        public async Task<int> DeleteAsync(string text)
        {
            var entity = await _context.Words.FirstOrDefaultAsync(x => x.Text == text);
            if (await _context.Words.AnyAsync(x => x.Text == entity.Text))
            {
              
                _context.Words.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            else
            {
                throw new WordExistException($"{text}  uygun soz tapilmadi,zehmet olmasa duzgun soz daxil edin ");
            }
        }

    }
}
