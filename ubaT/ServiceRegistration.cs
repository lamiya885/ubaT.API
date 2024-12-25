using ubaT.Services.Abstracts;
using ubaT.Services.Implement;

namespace ubaT
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService,LanguageService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IBannedWordService, BannedWordService>();
            services.AddScoped<IGameService, GameService>();
            return services;
        }
    }
}
