using MongoDB.Bson;
using System;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Operators;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;

namespace TaskoMask.Services.Monolith.Application.Tests.Unit.Membership.TestData
{
    internal static class OperatorObjectMother
    {
        private const string _email = "Test@TaskoMask.ir";
        private const string _userName = "TestUserName";
        private const string _displayName = "Test DisplayName";
        private const string _password = "Test_Pass";

        public static OperatorUpsertDto CreateNewOperatorUpsertDto()
        {
            return new OperatorUpsertDto
            {
                DisplayName = _displayName,
                Email = _email,
                UserName=_userName,
                Password=_password
            };
        }



        public static OperatorUpsertDto CreateNewOperatorUpsertDtoFromOperator(Operator @operator)
        {
            return new OperatorUpsertDto
            {
                Id= @operator.Id,
                DisplayName = @operator.DisplayName,
                Email = @operator.Email,
            };
        }
    }
}
