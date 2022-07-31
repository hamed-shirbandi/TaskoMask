using MongoDB.Bson;
using TaskoMask.Domain.DomainModel.Membership.Entities;

namespace TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class OperatorObjectMother
    {
        private const string _email = "Test@TaskoMask.ir";
        private const string _displayName = "Test DisplayName";
        private static string _id = ObjectId.GenerateNewId().ToString();

        public static Operator CreateNewOperator()
        {
            return new Operator(_id)
            {
                DisplayName = _displayName,
                Email = _email,
            };
        }



        public static Operator CreateNewOperatorWithEmail(string email)
        {
            return new Operator(_id)
            {
                DisplayName = _displayName,
                Email = email,
            };
        }


        public static Operator CreateNewOperatorWithId(string id)
        {
            return new Operator(id)
            {
                DisplayName = _displayName,
                Email = _email,
            };
        }


    }
}
