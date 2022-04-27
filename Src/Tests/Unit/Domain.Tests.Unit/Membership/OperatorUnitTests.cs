using FluentAssertions;
using System;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using Xunit;

namespace TaskoMask.Domain.Tests.Unit.Membership
{
    public class OperatorUnitTests
    {

        [Fact]
        public void Operator_Is_Constructed_Properly()
        {
            //Arrange
            var expectedEmail = "Test@MyMail.com";


            //Act
            var @operator = OperatorObjectMother.CreateNewOperatorWithEmail(expectedEmail);


            //Assert
            @operator.Id.Should().NotBeNullOrEmpty();
            @operator.Email.Should().Be(expectedEmail);
        }

    }
}
