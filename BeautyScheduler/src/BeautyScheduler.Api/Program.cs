using Microsoft.EntityFrameworkCore;
using BeautyScheduler.Data.DbContexts;
using BeautyScheduler.Service.Mappers;

namespace BeautyScheduler.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BeautySchedulerDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaulConnection"));
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutomapper(typeof(MappingProfile));
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