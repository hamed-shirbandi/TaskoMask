using System;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Entities;

namespace TaskoMask.Services.Tasks.Write.Api.Infrastructure.Data.DbContext;

/// <summary>
///
/// </summary>
public static class DbInitialization
{
    /// <summary>
    ///
    /// </summary>
    public static void InitialDatabasesAndSeedEssentialData(this IServiceProvider serviceProvider)
    {
        serviceProvider.SeedEssentialData();
        serviceProvider.CreateIndexes();
    }

    /// <summary>
    /// Drop database
    /// </summary>
    public static void DropDatabase(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetService<TaskWriteDbContext>();

        dbContext.DropDatabase();
    }

    /// <summary>
    /// Seed the necessary data that system needs
    /// </summary>
    private static void SeedEssentialData(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<TaskWriteDbContext>();

        // dbContext.Boards.InsertOneAsync(x)
    }

    /// <summary>
    /// Create index for collections
    /// </summary>
    private static void CreateIndexes(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<TaskWriteDbContext>();

        dbContext.Tasks.Indexes.CreateOneAsync(
            new CreateIndexModel<Task>(
                Builders<Task>.IndexKeys.Ascending(x => x.Id),
                new CreateIndexOptions() { Name = nameof(Task.Id), Unique = true }
            )
        );
        dbContext.Tasks.Indexes.CreateOneAsync(
            new CreateIndexModel<Task>(
                Builders<Task>.IndexKeys.Ascending(x => x.CardId.Value),
                new CreateIndexOptions() { Name = nameof(Task.CardId) }
            )
        );
    }
}
