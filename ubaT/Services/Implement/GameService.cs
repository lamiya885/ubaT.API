using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ubaT.DAL;
using ubaT.DTOs.Games;
using ubaT.Entities;
using ubaT.Exceptions.Game;
using ubaT.Services.Abstracts;

namespace ubaT.Services.Implement
{
    public class GameService(ubaTDbContext _context,IMapper _mapper,IMemoryCache _catche ) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
           Game game  = _mapper.Map<GameCreateDto,Game>(dto);
            if(await _context.Games.AnyAsync(x=>x.Id==game.Id))
            {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
            }
            else
            {
                throw new GameNotFound();
            }
        }

        public async Task<Guid> Edit(GameEditDto dto,Guid id)
        {
            if(await _context.Games.AnyAsync(x=>x.Id==id))
            {
            Game game = _mapper.Map<GameEditDto,Game>(dto);
             _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game.Id;

            }
            else
            {
                throw new GameNotFound();
            }
        }

        public async Task<Guid> Start (Guid Id)
        {
            if (await _context.Games.AnyAsync(x => x.Id == Id&& x.Score==null))
            {
             
            var entity = _context.Games.FirstOrDefault(x=>x.Id==Id);
           _catche.Set<Guid>(Id,entity.Id, DateTime.Now.AddSeconds(entity.Time));
           _catche.Set<Game>(Id,entity);
            return entity.Id;

            }
            else if(await _context.Games.AnyAsync(x => x.Id == Id && x.Score != null))
            {
                throw new  GameAllReadyFinished();

            }
            else
            {
                throw new GameNotFound();
            }
            GameStatusDto status=new GameStatusDto();
            {
                Fail=0,
                Skip=0,
                Success=0

            }

        }

        public Task<Guid> End()
        {
            
            throw new NotImplementedException();
        }
        public Task<Guid> Success(GameSuccessDto dto,Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Fail()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Skip()
        {
            throw new NotImplementedException();
        }

        
    }
}
