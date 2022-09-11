using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Application.Tests.Unit.TestData
{
    internal static class DataGenerator
    {


        public static List<User> GenerateUserList(int number = 3)
        {
            var list = new List<User>();

            for (int i = 1; i <= number; i++)
            {
                list.Add(new User
                {
                    UserName = $"UserName_{i}",
                    IsActive=false
                });
            }

            return list;
        }


    }
}
