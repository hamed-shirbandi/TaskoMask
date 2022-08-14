using FluentAssertions;
using System;
using TaskoMask.Services.Monolith.Domain.Core.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData;
using TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.ObjectMothers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using Xunit;

namespace TaskoMask.Services.Monolith.Domain.Tests.Unit.Membership
{
    public class OperatorUnitTests : TestsBase
    {

        [Fact]
        public void Operator_Is_Constructed()
        {
            //Arrange
            var expectedEmail = "New@TaskoMask.ir";

            //Act
            var @operator = OperatorObjectMother.CreateNewOperatorWithEmail(expectedEmail);

            //Assert
            @operator.Id.Should().NotBeNullOrEmpty();
            @operator.Email.Should().Be(expectedEmail);
        }


        [Fact]
        public void Operator_Is_Not_Constructed_When_Id_Is_Null()
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMessages.Null_Reference_Error, nameof(Operator.Id));

            //Act
            Action act = () => OperatorObjectMother.CreateNewOperatorWithId(null);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        /// <summary>
        /// Manage Test Fixture
        /// </summary>
        protected override void FixtureSetup()
        {

        }

    }
}
