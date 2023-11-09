using Microsoft.EntityFrameworkCore;
using BeautyScheduler.Data.DbContexts;
using BeautyScheduler.Service.Mappers;
using Microsoft.Extensions.DependencyInjection;
using BeautyScheduler.Api.Extentions;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Api.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Serilog;
using BeautyScheduler.Service.Helpers;
using BeautyScheduler.Api.Middlewares;

namespace BeautyScheduler.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BeautySchedulerDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           // builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // Service extentions
            builder.Services.AddCustomServices();
            
            // Automapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //Configure api url name
            builder.Services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(
                                                    new ConfigurationApiUrlName()));
            });

            // Logger
            var logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .Enrich.FromLogContext()
              .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            builder.Services.AddAuthorization();


            var app = builder.Build();

            WebEnvironmentHost.WebRootPath = Path.GetFullPath("wwwroot");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}