using AutoMapper;
using System.Runtime.CompilerServices;
using ubaT.DTOs.Words;
using ubaT.Entities;

namespace ubaT.Profiles
{
    public class WordProfile:Profile
    {
        public WordProfile()
        { 
          CreateMap<WordCreateDto,Word>()
                .ForMember(dest => dest.BannedWords, opt => opt.MapFrom(src => src.BannedWords!.Select(bw => new BannedWord { Text = bw }).ToList()))
                 ;
            CreateMap<WordUpdateDto,Word>();
          CreateMap<Word, WordGetDto>();
        }
    }
}
