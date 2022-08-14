
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Services;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using Xunit;

namespace TaskoMask.Services.Monolith.Application.Tests.Integration.Fixtures
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
        public readonly IProjectService ProjectService;
        private readonly IReadDbContext _readDbContext;

        public OwnerCollectionFixture() : base(dbNameSuffix: nameof(OwnerCollectionFixture))
        {
            SeedSampleData();
            OwnerService = GetRequiredService<IOwnerService>();
            OrganizationService = GetRequiredService<IOrganizationService>();
            ProjectService = GetRequiredService<IProjectService>();
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



        /// <summary>
        /// 
        /// </summary>
        public async Task<Project> GetSampleProjectAsync()
        {
            var _projects = _readDbContext.GetCollection<Project>();
            return await _projects.AsQueryable().Sample(1).SingleOrDefaultAsync();
        }


    }
}
