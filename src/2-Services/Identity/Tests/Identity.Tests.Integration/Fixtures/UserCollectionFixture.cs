using AutoMapper;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Identity.Api.Domain.Entities;
using Xunit;

namespace TaskoMask.Services.Identity.Tests.Integration.Fixtures;

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
    public INotificationService NotificationHandler;
    public IEventPublisher MessageBus;
    public IRequestDispatcher InMemoryBus;
    public IMapper Mapper;
    public IIdentityServerInteractionService InteractionService;
    public IEventService EventsService;

    public UserCollectionFixture()
        : base(dbNameSuffix: nameof(UserCollectionFixture))
    {
        UserManager = GetRequiredService<UserManager<User>>();
        SignInManager = GetRequiredService<SignInManager<User>>();
        SignInManager.Context = new DefaultHttpContext { RequestServices = _serviceProvider };
        NotificationHandler = GetRequiredService<INotificationService>();
        Mapper = GetRequiredService<IMapper>();

        InteractionService = Substitute.For<IIdentityServerInteractionService>();
        EventsService = Substitute.For<IEventService>();
        MessageBus = Substitute.For<IEventPublisher>();
        InMemoryBus = Substitute.For<IRequestDispatcher>();
    }

    /// <summary>
    ///
    /// </summary>
    public async Task SeedUserAsync(User user, string password)
    {
        await UserManager.CreateAsync(user, password);
    }
}
