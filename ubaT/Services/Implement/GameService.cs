using AutoMapper;
using ubaT.DAL;
using ubaT.DTOs.Games;
using ubaT.Entities;
using ubaT.Services.Abstracts;

namespace ubaT.Services.Implement
{
    public class GameService(ubaTDbContext _context,IMapper _mapper) : IGameService
    {
        public async Task CreateAsync(GameCreateDto dto)
        {
           Game game  = _mapper.Map<GameCreateDto,Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public Task Start(Guid Id)
        {
            throw new NotImplementedException();
        }
        public Task Edit()
        {
            throw new NotImplementedException();
        }

        public Task End()
        {
            throw new NotImplementedException();
        }

        public Task Fail()
        {
            throw new NotImplementedException();
        }

        public Task Skip()
        {
            throw new NotImplementedException();
        }


        public Task Success()
        {
            throw new NotImplementedException();
        }
    }
}
