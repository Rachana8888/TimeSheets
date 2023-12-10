using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SaggiTimeSheet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            string cs = "server=DESKTOP-1HGOK8T;user id=sa; password=ONShivaya;database=SaggiTimeSheet;trustservercertificate=true";
            builder.Services.AddDbContext<SaggiTimeSheetDbContext> (options=>options.UseSqlServer(cs));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}