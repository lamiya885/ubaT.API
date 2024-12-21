using AutoMapper;
using ubaT.DTOs.Languages;
using ubaT.Entities;

namespace ubaT.ProFiles
{
    public class LanguageProfile:Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>();
        }
    }
}
