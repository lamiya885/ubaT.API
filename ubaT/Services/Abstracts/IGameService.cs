using ubaT.DTOs.Games;

namespace ubaT.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<Guid> Start(Guid Id);
        Task<Guid> Success(GameSuccessDto dto,Guid id);
        Task<Guid> Fail();
        Task<Guid> Skip();
        Task<Guid> End();
        Task<Guid> Edit(GameEditDto dto,Guid Id);
    }
}
