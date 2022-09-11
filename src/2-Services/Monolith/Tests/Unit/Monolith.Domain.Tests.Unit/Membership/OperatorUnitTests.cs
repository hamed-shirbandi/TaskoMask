using FluentAssertions;
using System;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.ObjectMothers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using Xunit;
using TaskoMask.BuildingBlocks.Test;

namespace TaskoMask.Services.Monolith.Domain.Tests.Unit.Membership
{
    public class OperatorUnitTests : UnitTestsBase
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




        /// <summary>
        /// Manage Test Fixture
        /// </summary>
        protected override void FixtureSetup()
        {

        }

    }
}
