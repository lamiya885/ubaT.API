using ubaT.DTOs.Games;
using ubaT.DTOs.Words;

namespace ubaT.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<WordForGameDto> Start(Guid Id);
        Task<WordForGameDto> Success(Guid Id);
        Task<Guid> Fail(Guid Id );
        Task<WordForGameDto> Skip(Guid Id);
        Task<Guid> End(Guid Id);
        Task<Guid> Edit(GameEditDto dto,Guid Id);
    }
}
