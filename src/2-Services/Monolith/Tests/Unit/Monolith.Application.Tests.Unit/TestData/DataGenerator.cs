using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Application.Tests.Unit.TestData
{
    internal static class DataGenerator
    {

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
                var owner = Owner.RegisterOwner(ObjectId.GenerateNewId().ToString(), $"DisplayName_{i}", $"Email_{i}@mail.com");
                owner.ClearDomainEvents();
                list.Add(owner);
            }

            return list;
        }



    }
}
