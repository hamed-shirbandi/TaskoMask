using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Membership.Entities;

namespace TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class OperatorObjectMother
    {


        public static Operator CreateNewOperator()
        {
           return new Operator(ObjectId.GenerateNewId().ToString())
            {
                DisplayName = "TestOperatorName",
               Email = "Test@mail.com",
                
            };
        }



        public static Operator CreateNewOperatorWithEmail(string email)
        {
            return new Operator(ObjectId.GenerateNewId().ToString())
            {
                DisplayName = "TestOperatorName",
                Email = email,
            };
        }


        public static Operator CreateNewOperatorWithId(string id)
        {
            return new Operator(id)
            {
                DisplayName = "TestOperatorName",
                Email = "Test@mail.com",
            };
        }


    }
}
