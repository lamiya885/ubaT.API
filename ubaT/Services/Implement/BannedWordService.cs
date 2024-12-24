using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ubaT.DAL;
using ubaT.DTOs.BannedWords;
using ubaT.DTOs.Words;
using ubaT.Entities;
using ubaT.Exceptions.BannedWord;
using ubaT.Exceptions.Word;
using ubaT.Services.Abstracts;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ubaT.Services.Implement
{
    public class BannedWordService(IMapper _mapper,ubaTDbContext _context) : IBannedWordService
    {
        public async Task<IEnumerable<BannedWordGetDto>> GetAllAsync()
        {
            var datas = await _context.BannedWords.ToListAsync();
            return _mapper.Map<IEnumerable<BannedWordGetDto>>(datas);
     
        }

        public async Task<BannedWordGetDto> GetByTextAsync(string text)
        {
            var entity=await  _context.BannedWords.FirstOrDefaultAsync(x=>x.Text==text);
            if (await _context.BannedWords.AnyAsync(x => x.Text == entity.Text))
            {
             return _mapper.Map<BannedWordGetDto>(entity);

            }
            else
            {
                throw new BannedWordExistException($"{text}  uygun qadagan edilmis soz tapilmadi,zehmet olmasa duzgun qadagan edilmis soz daxil edin ");
            }
        }
        public async Task<int> CreateAsync(BannedWordCreateDto dto)
        {
            if (await _context.BannedWords.AnyAsync(x => x.Text == dto.Text))
                throw new BannedWordExistException();
            BannedWord bannedWord = _mapper.Map<BannedWord>(dto);

            await _context.BannedWords.AddAsync(bannedWord);
            await _context.SaveChangesAsync();
            return bannedWord.Id;
          //SQL-e dusmur.
        }

      

        public async Task<int> UpdateAsync(BannedWordUpdateDto dto,string text)
        {
            var entity= await _context.BannedWords.FirstOrDefaultAsync(x=>x.Text==text);
            if (await _context.BannedWords.AnyAsync(x => x.Text == entity.Text))
            {
            BannedWord upbannedWord= _mapper.Map<BannedWord>(dto);
                


                _context.BannedWords.Update(entity);
            await _context.SaveChangesAsync();
                return upbannedWord.Id;
            }
            else
            {
                throw new BannedWordExistException($"{text}  uygun qadagan edilmis  soz tapilmadi,zehmet olmasa duzgun  qadagan edilmis soz daxil edin ");
            }

      
        }

        public async Task<int> DeleteAsync(string text)
        {
            var entity = await _context.BannedWords.FirstOrDefaultAsync(x => x.Text == text);
            if (await _context.BannedWords.AnyAsync(x => x.Text == entity.Text))
            {
            _context.BannedWords.Remove(entity);
            await _context.SaveChangesAsync();
                return entity.Id;
            }
            else
            {
                throw new BannedWordExistException($"{text}  uygun qadagan edilmis  soz tapilmadi,zehmet olmasa duzgun qadagan edilmis soz daxil edin ");
            }
        }


    }
}
