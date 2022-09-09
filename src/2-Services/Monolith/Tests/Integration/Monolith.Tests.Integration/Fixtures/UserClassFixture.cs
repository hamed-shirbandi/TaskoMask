using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Authorization.Users.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;
using Xunit;

namespace TaskoMask.Services.Monolith.Application.Tests.Integration.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    public class UserClassFixture : TestsBaseFixture
    {
        public readonly IUserService UserService;
        private readonly IWriteDbContext _writeDbContext;
        
        public UserClassFixture( ) : base(dbNameSuffix: nameof(UserClassFixture))
        {
            SeedSampleData();
            UserService = GetRequiredService<IUserService>();
            _writeDbContext = GetRequiredService<IWriteDbContext>();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<User> GetSampleUserAsync()
        {
            var _users = _writeDbContext.GetCollection<User>();
            return await _users.AsQueryable().Sample(1).SingleOrDefaultAsync();
        }

    }
}
