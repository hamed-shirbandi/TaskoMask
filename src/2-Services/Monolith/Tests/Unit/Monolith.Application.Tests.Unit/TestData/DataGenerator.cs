using System.Collections.Generic;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Application.Tests.Unit.TestData
{
    internal static class DataGenerator
    {

  
        public static List<Owner> GenerateOwnerList(int number = 3)
        {
            var list = new List<Owner>();

            for (int i = 1; i <= number; i++)
            {
                var owner = Owner.RegisterOwner($"DisplayName_{i}", $"Email_{i}@mail.com");
                owner.ClearDomainEvents();
                list.Add(owner);
            }

            return list;
        }



    }
}
