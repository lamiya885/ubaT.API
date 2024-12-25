using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using ubaT.Exceptions;
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
        public static IApplicationBuilder UseubaTExceptionHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(
                opt =>
                {
                    opt.Run(async context =>
                    {
                        var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                        var exception = feature.Error;
                        if (exception is IBaseException Bex)
                        {
                            context.Response.StatusCode = Bex.StatusCode;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = Bex.ErrorMessage
                            });
                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = "Bir xeta bash verdi"
                            });
                        }
                    });
                });
            return app;
        }
    }
}
