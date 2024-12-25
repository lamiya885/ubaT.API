using AutoMapper;
using ubaT.DTOs.Games;
using ubaT.Entities;

namespace ubaT.Profiles
{
    public class GameProfile:Profile
    {
        public GameProfile() 
        {
            CreateMap<GameCreateDto, Game>();
            CreateMap<GameEditDto, Game>();
        
        }
    }
}
