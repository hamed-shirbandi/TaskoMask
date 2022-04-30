
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Owners.Services;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;
using Xunit;

namespace TaskoMask.Application.Tests.Integration.TestData.Fixtures
{

    [CollectionDefinition(nameof(OwnerCollectionFixture))]
    public class OwnerCollectionFixtureDefinition : ICollectionFixture<OwnerCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }


    public class OwnerCollectionFixture : TestsBaseFixture
    {
        public readonly IOwnerService OwnerService;
        private readonly IWriteDbContext _writeDbContext;

        public OwnerCollectionFixture() : base(dbNameSuffix: nameof(OwnerCollectionFixture))
        {
            SeedSampleData();
            OwnerService = GetRequiredService<IOwnerService>();
            _writeDbContext = GetRequiredService<IWriteDbContext>();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Owner> GetSampleOwnerAsync()
        {
            var _users = _writeDbContext.GetCollection<Owner>();
            return await _users.AsQueryable().Sample(1).SingleOrDefaultAsync();
        }
    }
}
