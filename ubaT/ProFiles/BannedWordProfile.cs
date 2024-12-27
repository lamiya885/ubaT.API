using AutoMapper;
using ubaT.DTOs.BannedWords;
using ubaT.Entities;

namespace ubaT.Profiles
{
    public class BannedWordProfile:Profile
    {
        public BannedWordProfile ()
        {
            CreateMap<BannedWordCreateDto,BannedWord>();
            .
            CreateMap<BannedWordUpdateDto,BannedWord>();
            CreateMap<BannedWord, BannedWordGetDto>();

        }

    }
}
