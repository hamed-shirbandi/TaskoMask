using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TaskoMask.Services.Identity.Application.Users.Services;
using TaskoMask.Services.Identity.Domain.Entities;
using TaskoMask.Services.Identity.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Identity.Application.Tests.Integration.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    public class UserClassFixture : TestsBaseFixture
    {
        public readonly IUserService UserService;
        private readonly IIdentityDbContext _identityDbContext;
        
        public UserClassFixture( ) : base(dbNameSuffix: nameof(UserClassFixture))
        {
            SeedSampleData();
            UserService = GetRequiredService<IUserService>();
            _identityDbContext = GetRequiredService<IIdentityDbContext>();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<User> GetSampleUserAsync()
        {
            var _users = _identityDbContext.GetCollection<User>();
            return await _users.AsQueryable().Sample(1).SingleOrDefaultAsync();
        }

    }
}
