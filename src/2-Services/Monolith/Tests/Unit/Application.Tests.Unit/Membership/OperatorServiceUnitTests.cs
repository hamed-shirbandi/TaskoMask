using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Authorization.Users.Services;
using TaskoMask.Services.Monolith.Application.Membership.Operators.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Application.Tests.Unit.Membership.TestData;
using TaskoMask.Services.Monolith.Application.Tests.Unit.TestData;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using Xunit;

namespace TaskoMask.Services.Monolith.Application.Tests.Unit.Membership
{
    public class OperatorServiceUnitTests: TestsBase
    {
        #region Fields

        private IOperatorRepository _operatorRepository;
        private IRoleRepository _roleRepository;
        private IUserService _userService;
        private IOperatorService _operatorService;
        private List<Operator> _operators;

        #endregion

        #region Test Methods



        [Fact]
        public async void Operator_Is_Created()
        {
            //Arrange
            var operatorDto = OperatorObjectMother.CreateNewOperatorUpsertDto();

            //Act
            var result = await _operatorService.CreateAsync(operatorDto);

            //Asserrt
            result.IsSuccess.Should().Be(true);
            var createdUser = _operators.FirstOrDefault(u => u.Id == result.Value.EntityId);
            createdUser.Email.Should().Be(operatorDto.Email);
        }



        [Fact]
        public async void Operator_Is_Updated_Properly( )
        {
            //Arrange
            var expectedEmail = "Test_2@TaskoMask.ir";
            var operatorToUpdate = _operators.First();
            var operatorDto = OperatorObjectMother.CreateNewOperatorUpsertDtoFromOperator(operatorToUpdate);

            //Act
            operatorDto.Email = expectedEmail;
            var result = await _operatorService.UpdateAsync(operatorDto);

            //Asserrt
            result.IsSuccess.Should().Be(true);
            operatorToUpdate.Email.Should().Be(expectedEmail);
        }



        #endregion

        #region Private Methods

        protected override void TestClassFixtureSetup()
        {
            _operators = DataGenerator.GenerateOperatorList();

            _roleRepository = Substitute.For<IRoleRepository>();

            _userService = Substitute.For<IUserService>();
            _userService.CreateAsync(Arg.Any<string>(), Arg.Any<string>(), UserType.Operator).Returns(Result.Success(new CommandResult(entityId: ObjectId.GenerateNewId().ToString())));
            _userService.UpdateUserNameAsync(Arg.Is<string>(arg => _operators.Select(o => o.Id).Any(id => id == arg)), Arg.Any<string>()).Returns(args => Result.Success(new CommandResult(entityId: (string)args[0])));

            _operatorRepository = Substitute.For<IOperatorRepository>();
            _operatorRepository.GetByIdAsync(Arg.Is<string>(x => _operators.Any(u => u.Id == x))).Returns(args => _operators.First(u => u.Id == (string)args[0]));
            _operatorRepository.CreateAsync(Arg.Any<Operator>()).Returns(async args => _operators.Add((Operator)args[0]));
            _operatorRepository.UpdateAsync(Arg.Is<Operator>(x => _operators.Any(u => u.Id == x.Id))).Returns(async args =>
            {
                var existUser = _operators.FirstOrDefault(u => u.Id == ((Operator)args[0]).Id);
                if (existUser != null)
                {
                    _operators.Remove(existUser);
                    _operators.Add(((Operator)args[0]));
                }
            });
            _operatorService = new OperatorService(_inMemoryBus, _iMapper, _domainNotificationHandler, _operatorRepository, _roleRepository, _userService);
        }



        #endregion
    }
}
