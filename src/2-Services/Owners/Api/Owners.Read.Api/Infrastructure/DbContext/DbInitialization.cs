using System;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

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

        var dbContext = serviceScope.ServiceProvider.GetService<OwnerReadDbContext>();

        dbContext.DropDatabase();
    }

    /// <summary>
    /// Create index for collections
    /// </summary>
    private static void CreateIndexes(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<OwnerReadDbContext>();

        #region Owner Indexs

        dbContext.Owners.Indexes.CreateOneAsync(
            new CreateIndexModel<Owner>(
                Builders<Owner>.IndexKeys.Ascending(x => x.Id),
                new CreateIndexOptions() { Name = nameof(Owner.Id), Unique = true }
            )
        );
        dbContext.Owners.Indexes.CreateOneAsync(
            new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Email), new CreateIndexOptions() { Name = nameof(Owner.Email) })
        );
        dbContext.Owners.Indexes.CreateOneAsync(
            new CreateIndexModel<Owner>(
                Builders<Owner>.IndexKeys.Ascending(x => x.DisplayName),
                new CreateIndexOptions() { Name = nameof(Owner.DisplayName) }
            )
        );

        #endregion

        #region Organization Indexs

        dbContext.Organizations.Indexes.CreateOneAsync(
            new CreateIndexModel<Organization>(
                Builders<Organization>.IndexKeys.Ascending(x => x.Id),
                new CreateIndexOptions() { Name = nameof(Organization.Id), Unique = true }
            )
        );
        dbContext.Organizations.Indexes.CreateOneAsync(
            new CreateIndexModel<Organization>(
                Builders<Organization>.IndexKeys.Ascending(x => x.OwnerId),
                new CreateIndexOptions() { Name = nameof(Organization.OwnerId) }
            )
        );

        #endregion

        #region Project Indexs

        dbContext.Projects.Indexes.CreateOneAsync(
            new CreateIndexModel<Project>(
                Builders<Project>.IndexKeys.Ascending(x => x.Id),
                new CreateIndexOptions() { Name = nameof(Project.Id), Unique = true }
            )
        );
        dbContext.Projects.Indexes.CreateOneAsync(
            new CreateIndexModel<Project>(
                Builders<Project>.IndexKeys.Ascending(x => x.OrganizationId),
                new CreateIndexOptions() { Name = nameof(Project.OrganizationId) }
            )
        );

        #endregion
    }
}
