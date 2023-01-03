using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Tests.Unit.Helpers
{
    public class TestUserManager : UserManager<User>
    {
        public TestUserManager() : base(Substitute.For<IUserStore<User>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<IPasswordHasher<User>>(), Substitute.For<IEnumerable<IUserValidator<User>>>(), Substitute.For<IEnumerable<IPasswordValidator<User>>>(), Substitute.For<ILookupNormalizer>(), Substitute.For<IdentityErrorDescriber>(), Substitute.For<IServiceProvider>(), Substitute.For<ILogger<UserManager<User>>>())
        {
        }
    }
}
