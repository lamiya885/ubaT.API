using AutoMapper;
using ubaT.DTOs.Languages;
using ubaT.Entities;

namespace ubaT.Profiles
{
    public class LanguageProfile:Profile
    {
        public LanguageProfile()
        {
        CreateMap<LanguageCreateDto, Language>()
                .ForMember(l=>l.Icon,lcd=>lcd.MapFrom(x=>x.IconUrl));
            CreateMap<Language, LanguageGetDto>();
            CreateMap<LanguageUpdateDto, Language>();


        }
    }
}
