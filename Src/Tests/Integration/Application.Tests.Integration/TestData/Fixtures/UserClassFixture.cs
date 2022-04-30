using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;
using Xunit;

namespace TaskoMask.Application.Tests.Integration.TestData.Fixtures
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
