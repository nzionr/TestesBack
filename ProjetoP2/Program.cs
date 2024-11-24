
using Microsoft.EntityFrameworkCore;
using ProjetoP2.Contexto;

namespace ProjetoP2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<RoletaContextMySQL>(options => {
                options.UseMySQL(builder.Configuration.GetConnectionString("BancoMySQL"));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(x => x.WithOrigins("https://localhost:7231", "http://localhost:5173", "http://localhost:5174")
               .AllowAnyMethod()
               .AllowAnyHeader());
            app.MapControllers();
                
            app.Run();
        }
    }
}
