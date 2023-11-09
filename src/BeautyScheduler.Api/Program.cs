using Microsoft.EntityFrameworkCore;
using BeautyScheduler.Data.DbContexts;
using BeautyScheduler.Service.Mappers;
using Microsoft.Extensions.DependencyInjection;
using BeautyScheduler.Api.Extentions;
using BeautyScheduler.Data.IRepositories;

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
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}