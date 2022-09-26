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
        public UserManager<User> UserManager;
        public SignInManager<User> SignInManager;
        public IIdentityServerInteractionService InteractionService;
        public IEventService EventsService;

        public UserClassFixture() : base(dbNameSuffix: nameof(UserClassFixture))
        {
            UserManager = GetRequiredService<UserManager<User>>();
            SignInManager = GetRequiredService<SignInManager<User>>();
            InteractionService = GetRequiredService<IIdentityServerInteractionService>();
            EventsService = GetRequiredService<IEventService>();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<User> GetSampleUserAsync()
        {
            return await UserManager.Users.OrderBy(r => Guid.NewGuid()).Take(1).SingleOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task SeedUserAsync(User user,string password)
        {
            await UserManager.CreateAsync(user,password);
        }

    }
}