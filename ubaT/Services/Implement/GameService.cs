using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ubaT.DAL;
using ubaT.DTOs.Games;
using ubaT.DTOs.Words;
using ubaT.Entities;
using ubaT.Exceptions.Game;
using ubaT.Extension;
using ubaT.Services.Abstracts;
using TimeSpan = System.TimeSpan;

namespace ubaT.Services.Implement
{
    public class GameService(ubaTDbContext _context, IMapper _mapper, IMemoryCache _cache) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            Game game = _mapper.Map<Game>(dto);
            if (await _context.Games.AnyAsync(x => x.Id == game.Id))
            {
                throw new Exception();
            }
            else
            {
                await _context.Games.AddAsync(game);
                await _context.SaveChangesAsync();
                return game.Id;
            }
        }

        public async Task<Guid> Edit(GameEditDto dto, Guid id)
        {
            if (await _context.Games.AnyAsync(x => x.Id == id))
            {
                Game game = _mapper.Map<GameEditDto, Game>(dto);
                _context.Games.Update(game);
                await _context.SaveChangesAsync();
                return game.Id;

            }
            else
            {
                throw new GameNotFound();
            }
        }

        public async Task<WordForGameDto> Start(Guid Id)
        {
            var game = await _context.Games.FindAsync(Id);
            if (game.Score==null)
            {
                throw new Exception();
            }
            IQueryable<Word> query = _context.Words
                 .Where(x => x.LangCode == game.LangCode);
            var words = await query
                .Select(x => new WordForGameDto
                {
                    Id = x.Id,
                    Word = x.Text,
                    BannedWords = x.BannedWords.Select(y => y.Text)
                })
                .Random(await query.CountAsync())
                .Take(20)
                .ToListAsync();

            var wordsStack = new Stack<WordForGameDto>(words);
            WordForGameDto currentWord = wordsStack.Pop();
            GameStatusDto status = new GameStatusDto()
            {
                Fail = 0,
                Success = 0,
                Skip = 0,
                Words = wordsStack,
                MaxSkipCount = game.SkipCount,
                UssedWordIds = words.Select(x => x.Id)
            };

            _cache.Set(Id, status, TimeSpan.FromSeconds(300));

            return currentWord;


            //if (game == null || game.Score == null)
            //{
            //    IQueryable<Word> query = _context.Words
            //        .Where(x => x.LangCode == game.LangCode);
            //    var words = await query
            //        .Select(x => new WordForGameDto
            //        {
            //            Id = x.Id,
            //            Word = x.Text,
            //            BannedWords = x.BannedWords.Select(y => y.Text)
            //        })
            //        .Random(await query.CountAsync())
            //        .Take(20)
            //        .ToListAsync();

            //    var wordsStack = new Stack<WordForGameDto>(words);
            //    WordForGameDto currentWord = wordsStack.Pop();
            //    GameStatusDto status = new GameStatusDto()
            //    {
            //        Fail = 0,
            //        Success = 0,
            //        Skip = 0,
            //        Words = wordsStack,
            //        MaxSkipCount = game.SkipCount,
            //        UssedWordIds = words.Select(x => x.Id)
            //    };

            //    _cache.Set(Id, status, TimeSpan.FromSeconds(300));

            //    return currentWord;


            //}
            //else if (game != null || game.Score != null)
            //{
            //    throw new GameAllReadyFinished();
            //}
            //else
            //{
            //    throw new GameNotFound();
            //}


            //SQL de startedTime saxla, success;fail;skip oyunun bitib bitmediyini yoxla, eger istifadeci 20den cox soz bilse 5 soz getirsin

            //  _cache.Set(Id, status,TimeSpan.FromSeconds(game.Time+20)); 
            // if (await _context.Games.AnyAsync(x => x.Id == Id&& x.Score==null))
            // {

            // var entity = _context.Games.FirstOrDefault(x=>x.Id==Id);
            //_catche.Set<Guid>(Id,entity.Id, DateTime.Now.AddSeconds(entity.Time));
            //_catche.Set<Game>(Id,entity);
            // return entity.Id;

            // }
            // else if(await _context.Games.AnyAsync(x => x.Id == Id && x.Score != null))
            // {
            //     throw new  GameAllReadyFinished();

            // }
            // else
            // {
            //     throw new GameNotFound();
            // }
            // GameStatusDto status=new GameStatusDto();
            // {
            //     Fail=0,
            //     Skip=0,
            //     Success=0

            // }

        }

        public async Task<Guid> End(Guid Id)
        {
            var game = await _context.Games.FindAsync(Id);
            if (game.Time==0)
            {
                return game.Id;
            }
            else 
            {
                throw new GameCanNotEnd();
            }


        }
        public async Task<WordForGameDto> Success(Guid Id)
        {
            var status = _getCurrentGame(Id);
            Game game = _context.Games.Find(Id);
            WordForGameDto currentWord = status.Words.Pop();
            status.Success++;
            game.Score++;
            _cache.Set(Id, status, TimeSpan.FromSeconds(300));

            return currentWord;
            //return currentWord;
            //if(game != null )
            //var status = _getCurrentGame(Id);
            //Game game = _context.Games.Find(Id);
            //WordForGameDto currentWord = status.Words.Pop();
            //status.Success++;
            //game.Score++;
            //_cache.Set(Id, status, TimeSpan.FromSeconds(300));

            //return currentWord;
        }
        public async Task<WordForGameDto> Fail(Guid Id)
        {
            var status = _getCurrentGame(Id);
            Game game = _context.Games.Find(Id);
            var currentWord = status.Words.Pop();
            status.Fail++;
            game.Score = game.SuccessAnswer - (game.WrongAnswer / game.FailCount);

            return currentWord;
        }

        public async Task<WordForGameDto> Skip(Guid Id)
        {
            var status = _getCurrentGame(Id);
            if (status.Skip <= status.MaxSkipCount)
            {
                var currentWord = status.Words.Pop();
                status.Skip++;
                _cache.Set(Id, status, TimeSpan.FromSeconds(300));
                return currentWord;
            }
            return null;
        }
        GameStatusDto _getCurrentGame(Guid id)
        {

            var result = _cache.Get<GameStatusDto>(id);
            if (result == null) throw new GameNotFound();
            return result;
        }


    }
}
