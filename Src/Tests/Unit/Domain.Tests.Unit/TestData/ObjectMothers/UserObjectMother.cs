using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.DomainModel.Authorization.Entities;

namespace TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class UserObjectMother
    {


        public static User CreateNewUser()
        {
           return new User
            {
                UserName = "TestUserName",
            };
        }


        public static User CreateNewUser(string userName)
        {
            return new User
            {
                UserName = userName,
            };
        }



        public static User CreateNewUser(string userName,bool isActive)
        {
            return new User
            {
                UserName = userName,
                IsActive = isActive,
            };
        }
    }
}
