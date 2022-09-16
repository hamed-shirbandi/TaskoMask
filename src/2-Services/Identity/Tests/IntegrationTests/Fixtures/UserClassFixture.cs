using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.IntegrationTests.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    public class UserClassFixture : TestsBaseFixture
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;

        public UserClassFixture() : base(dbNameSuffix: nameof(UserClassFixture))
        {
            SeedSampleData();
            _userManager = GetRequiredService<UserManager<User>>();
            _signInManager = GetRequiredService<SignInManager<User>>();
            _interaction = GetRequiredService<IIdentityServerInteractionService>();
            _events = GetRequiredService<IEventService>();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<User> GetSampleUserAsync()
        {
            return await _userManager.Users.OrderBy(r => Guid.NewGuid()).Take(1).SingleOrDefaultAsync();
        }

    }
}