using MongoDB.Driver;

namespace TaskoMask.Services.Owner.Read.Api.Infrastructure.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbInitialization
    {


        /// <summary>
        /// Seed the necessary data that system needs
        /// </summary>
        public static void SeedEssentialData(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var _dbContext = serviceScope.ServiceProvider.GetService<OwnerReadDbContext>();
            var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();

            // var _owners = _dbContext.GetCollection<Owner>();
            // seed data ...
        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        public static void CreateIndexes( IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<OwnerReadDbContext>();

            //dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Owner.Id), Unique = true }));
            //dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Email.Value), new CreateIndexOptions() { Name = nameof(Owner.Email) }));
            //dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.DisplayName.Value), new CreateIndexOptions() { Name = nameof(Owner.DisplayName) }));
        }

    }
}
