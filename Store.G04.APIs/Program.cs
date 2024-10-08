
using Microsoft.EntityFrameworkCore;
using Store.G04.Core;
using Store.G04.Core.Mapping;
using Store.G04.Repository;
using Store.G04.Repository.Data.Context;
using Store.G04.Services.Services;


namespace Store.G04.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault"))
            );

            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(m => m.AddProfile(new ProductProfile(builder.Configuration)));


            var app = builder.Build();

            // To Apply Migration

            using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            var context = Services.GetRequiredService<StoreDbContext>();
            var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
                await StoreDbContextSeed.SeedAsync(context);
            }catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "There are problem during Apply Migration !");
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
