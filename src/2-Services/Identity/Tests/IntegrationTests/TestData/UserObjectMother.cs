using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.IntegrationTests.TestData
{
    internal static class UserObjectMother
    {
        public static User GetActiveUserWithEmail(string email)
        {
            return new User
            {
                UserName = email,
                Email = email,
                IsActive = true,
            };
        }

    }
}
