using AutoMapper;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
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
        public INotificationHandler NotificationHandler;
        public IMessageBus MessageBus;
        public IInMemoryBus InMemoryBus;
        public IMapper Mapper;
        public IIdentityServerInteractionService InteractionService;
        public IEventService EventsService;

        public UserClassFixture() : base(dbNameSuffix: nameof(UserClassFixture))
        {
            UserManager = GetRequiredService<UserManager<User>>();
            SignInManager = GetRequiredService<SignInManager<User>>();
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
        public async Task SeedUserAsync(User user,string password)
        {
            await UserManager.CreateAsync(user,password);
        }

    }
}