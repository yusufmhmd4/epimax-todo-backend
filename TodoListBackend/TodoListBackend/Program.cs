
using Microsoft.EntityFrameworkCore;
using TodoListBackend.Entities;

namespace TodoListBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("todosConnectionString")));

            var app = builder.Build();

                app.UseSwagger();
                app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(configurePolicy =>
            {
                configurePolicy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
