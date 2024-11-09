using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Identity.Api.Domain.Entities;

namespace TaskoMask.Services.Identity.Api.Infrastructure.Data.DbContext;

/// <summary>
///
/// </summary>
public static class DbInitialization
{
    /// <summary>
    ///
    /// </summary>
    public static void InitialDatabase(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetService<IdentityDbContext>();

        dbContext.Database.EnsureCreated();
    }

    /// <summary>
    /// Seed the necessary data that system needs
    /// </summary>
    public static void SeedEssentialData(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
        var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

        SeedSuperUser(userManager, configuration).Wait();
    }

    /// <summary>
    ///
    /// </summary>
    public static void DropDatabase(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetService<IdentityDbContext>();

        dbContext.Database.EnsureDeleted();
    }

    /// <summary>
    ///
    /// </summary>
    private static async Task SeedSuperUser(UserManager<User> userManager, IConfiguration configuration)
    {
        var superUserEmail = configuration["Identity:SuperUser:Email"];
        var superUserName = configuration["Identity:SuperUser:UserName"];

        if (await userManager.FindByEmailAsync(superUserEmail) == null)
        {
            var superUser = new User(Guid.NewGuid().ToString())
            {
                UserName = superUserName,
                Email = superUserEmail,
                IsActive = true,
            };

            var password = configuration["Identity:SuperUser:Password"];
            await userManager.CreateAsync(superUser, password);
        }
    }
}
