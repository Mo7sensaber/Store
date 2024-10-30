using Store.Middlewares;
using Store.Repositorty.Data.Contexts;
using Store.Repositorty.Data;
using Microsoft.EntityFrameworkCore;
using Store.Repositorty.Identity.Contexts;
using Microsoft.AspNetCore.Identity;
using Store.Core.Entities.Identity;

namespace Store.Helper
{
    public static class ConfigureMiddleware 

    {
        public static async Task<WebApplication> ConfigureMiddlewareAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<StoreDBContext>();
            var IdentityContext = services.GetRequiredService<StoreIdentityDbContext>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
                await StoreDbContextSeed.SeedAsync(context);
                await IdentityContext.Database.MigrateAsync();
                await StoreIdentityDbContext.SeedAppUserAsync(userManager);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "ther are problems during apply migrations");
            }
            app.UseMiddleware<ExeptionsMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            return app;
        }
    }
}
