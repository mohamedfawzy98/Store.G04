using Store.G04.Repository.Data.Context;
using Store.G04.Repository;
using Microsoft.EntityFrameworkCore;

namespace Store.G04.APIs
{
    public static class ConfigureMiddelware
    {
        public static async Task<WebApplication> ConfigureMiddelwareAsync(this WebApplication app)
        {
            // To Apply Migration

            using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            var context = Services.GetRequiredService<StoreDbContext>();
            var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
                await StoreDbContextSeed.SeedAsync(context);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "There are problem during Apply Migration !");
            }
            // Configer userDefiend MiddelWare

            //app.UseMiddleware<ExpectionMiddelWare>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // middel wire to handel not found endpoint

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();


            return app;
        }
    }
}
