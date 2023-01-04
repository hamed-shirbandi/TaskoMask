using AutoMapper;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.Services.Identity.Domain.Entities;
using Xunit;

namespace TaskoMask.Services.Identity.Tests.Integration.Fixtures
{


    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition(nameof(UserCollectionFixture))]
    public class OwnerCollectionFixtureDefinition : ICollectionFixture<UserCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }




    /// <summary>
    /// 
    /// </summary>
    public class UserCollectionFixture : TestsBaseFixture
    {
        public UserManager<User> UserManager;
        public SignInManager<User> SignInManager;
        public INotificationHandler NotificationHandler;
        public IMessageBus MessageBus;
        public IInMemoryBus InMemoryBus;
        public IMapper Mapper;
        public IIdentityServerInteractionService InteractionService;
        public IEventService EventsService;

        public UserCollectionFixture() : base(dbNameSuffix: nameof(UserCollectionFixture))
        {
            UserManager = GetRequiredService<UserManager<User>>();
            SignInManager = GetRequiredService<SignInManager<User>>();
            SignInManager.Context = new DefaultHttpContext { RequestServices = _serviceProvider };
            NotificationHandler = GetRequiredService<INotificationHandler>();
            Mapper = GetRequiredService<IMapper>();

            InteractionService = Substitute.For<IIdentityServerInteractionService>();
            EventsService = Substitute.For<IEventService>();
            MessageBus = Substitute.For<IMessageBus>();
            InMemoryBus = Substitute.For<IInMemoryBus>();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task SeedUserAsync(User user, string password)
        {
            await UserManager.CreateAsync(user, password);
        }

    }
}