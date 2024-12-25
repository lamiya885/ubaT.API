
using Microsoft.EntityFrameworkCore;
using ubaT.DAL;
using ubaT.Services.Abstracts;
using ubaT.Services.Implement;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Diagnostics;
using ubaT.Exceptions;

namespace ubaT
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ubaTDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            builder.Services.AddMemoryCache();
            builder.Services.AddServices();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Run(async context=>
            {
                Console.WriteLine("Middleware worked");

            });

            app.UseExceptionHandler(
                opt =>
                {
                    opt.Run(async context =>
                    {

                        var feature = context.Features.GetRequiredFeature<ExceptionHandlerFeature>();
                       var exception = feature.Error;
                        if (exception is IBaseException Bex)
                        {
                            context.Response.StatusCode=Bex.StatusCode;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message=Bex.ErrorMessage
                            });
                            //return StatusCode(Bex.StatusCode, new
                            //{
                            //    Mesage = Bex.ErrorMessage
                            //});

                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message ="Bir xeta bash verdi"
                            });
                            //return BadRequest(new
                            //{
                            //    Message = exception.Message
                            //});
                        }
                    });
                });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
