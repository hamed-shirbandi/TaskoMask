using System;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

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
        serviceProvider.CreateIndexes();
    }

    /// <summary>
    /// Drop database
    /// </summary>
    public static void DropDatabase(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetService<BoardReadDbContext>();

        dbContext.DropDatabase();
    }

    /// <summary>
    /// Create index for collections
    /// </summary>
    private static void CreateIndexes(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<BoardReadDbContext>();

        #region Board Indexs

        dbContext.Boards.Indexes.CreateOneAsync(
            new CreateIndexModel<Board>(
                Builders<Board>.IndexKeys.Ascending(x => x.Id),
                new CreateIndexOptions() { Name = nameof(Board.Id), Unique = true }
            )
        );
        dbContext.Boards.Indexes.CreateOneAsync(
            new CreateIndexModel<Board>(
                Builders<Board>.IndexKeys.Ascending(x => x.ProjectId),
                new CreateIndexOptions() { Name = nameof(Board.ProjectId) }
            )
        );

        #endregion


        #region Card Indexs

        dbContext.Cards.Indexes.CreateOneAsync(
            new CreateIndexModel<Card>(
                Builders<Card>.IndexKeys.Ascending(x => x.Id),
                new CreateIndexOptions() { Name = nameof(Card.Id), Unique = true }
            )
        );
        dbContext.Cards.Indexes.CreateOneAsync(
            new CreateIndexModel<Card>(
                Builders<Card>.IndexKeys.Ascending(x => x.BoardId),
                new CreateIndexOptions() { Name = nameof(Card.BoardId), Unique = false }
            )
        );

        #endregion
    }
}
