
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Organizations.Services;
using TaskoMask.Application.Workspace.Owners.Services;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;
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
        public readonly IOrganizationService OrganizationService;
        private readonly IReadDbContext _readDbContext;

        public OwnerCollectionFixture() : base(dbNameSuffix: nameof(OwnerCollectionFixture))
        {
            SeedSampleData();
            OwnerService = GetRequiredService<IOwnerService>();
            OrganizationService = GetRequiredService<IOrganizationService>();
            _readDbContext = GetRequiredService<IReadDbContext>();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Owner> GetSampleOwnerAsync()
        {
            var _owners = _readDbContext.GetCollection<Owner>();
            return await _owners.AsQueryable().Sample(1).SingleOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Organization> GetSampleOrganizationAsync()
        {
            var _organizations = _readDbContext.GetCollection<Organization>();
            return await _organizations.AsQueryable().Sample(1).SingleOrDefaultAsync();
        }


    }
}
