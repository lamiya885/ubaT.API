using AutoMapper;
using ubaT.DTOs.Words;
using ubaT.Entities;

namespace ubaT.Profiles
{
    public class WordProfile:Profile
    {
        public WordProfile()
        { 
          CreateMap<WordCreateDto,Word>();
          CreateMap<WordUpdateDto,Word>();
          CreateMap<Word, WordGetDto>();
        }
    }
}
