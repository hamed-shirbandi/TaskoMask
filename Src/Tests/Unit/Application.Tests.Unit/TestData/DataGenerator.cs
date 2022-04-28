using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Application.Tests.Unit.TestData
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
                });
            }

            return list;
        }



        public static List<Operator> GenerateOperatorList(int number = 3)
        {
            var list = new List<Operator>();

            for (int i = 1; i <= number; i++)
            {
                list.Add(new Operator(ObjectId.GenerateNewId().ToString())
                {
                    Email = $"email_{i}@test.com",
                });
            }

            return list;
        }



        public static List<Owner> GenerateOwnerList(int number = 3)
        {
            var list = new List<Owner>();

            for (int i = 1; i <= number; i++)
            {
                var owner = Owner.CreateOwner(ObjectId.GenerateNewId().ToString(), $"DisplayName_{i}", $"Email_{i}@mail.com");
                owner.ClearDomainEvents();
                list.Add(owner);
            }

            return list;
        }



    }
}
