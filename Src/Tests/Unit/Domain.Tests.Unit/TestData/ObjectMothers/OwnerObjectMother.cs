using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class OwnerObjectMother
    {


        public static Owner CreateNewOwner()
        {
           return  OwnerBuilder.Init()
                  .WithId(ObjectId.GenerateNewId().ToString())
                  .WithEmail("Test@email.com")
                  .WithDisplayName("Test Name")
                  .Build();
        }



        public static Owner CreateNewOwnerWithId(string id)
        {
            return OwnerBuilder.Init()
                   .WithId(id)
                   .WithEmail("Test@email.com")
                   .WithDisplayName("Test Name")
                   .Build();
        }



        public static Owner CreateNewOwnerWithDisplayName(string displayName)
        {
            return OwnerBuilder.Init()
                   .WithId(ObjectId.GenerateNewId().ToString())
                   .WithEmail("Test@email.com")
                   .WithDisplayName(displayName)
                   .Build();
        }


        public static Owner CreateNewOwnerWithEmail(string email)
        {
            return OwnerBuilder.Init()
                   .WithId(ObjectId.GenerateNewId().ToString())
                   .WithEmail(email)
                   .WithDisplayName("Test Name")
                   .Build();
        }

    }
}
