using ubaT.DTOs.Games;

namespace ubaT.Services.Abstracts
{
    public interface IGameService
    {
        Task CreateAsync(GameCreateDto dto);
        Task Start(Guid Id);
        Task Success();
        Task Fail();
        Task Skip();
        Task End();
        Task Edit();
    }
}
