using AutoMapper;
using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Membership.Operators.Services;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Tests.Unit.Membership.TestData;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.WriteModel.Authorization.Data;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using TaskoMask.Domain.WriteModel.Membership.Data;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using Xunit;

namespace TaskoMask.Application.Tests.Unit.Membership
{
    public class OperatorServiceUnitTests
    {
        #region Fields

        private IInMemoryBus _dummyInMemoryBus;
        private IMapper _dummyIMapper;
        private IDomainNotificationHandler _dummyDomainNotificationHandler;
        private IOperatorRepository _operatorRepositoryStub;
        private IRoleRepository _roleRepositoryStub;
        private IUserService _userServiceStub;
        private IOperatorService _operatorService;
        private List<Operator> _operators;

        #endregion


        public OperatorServiceUnitTests()
        {
            ImplicitFixtureSetup();
        }





        #region Private Methods

        private void ImplicitFixtureSetup()
        {
            _dummyInMemoryBus = Substitute.For<IInMemoryBus>();
            _dummyIMapper = Substitute.For<IMapper>();
            _dummyDomainNotificationHandler = Substitute.For<IDomainNotificationHandler>();
            _roleRepositoryStub = Substitute.For<IRoleRepository>();
            
            _userServiceStub = Substitute.For<IUserService>();
            _userServiceStub.CreateAsync(Arg.Any<string>(), Arg.Any<string>()).Returns(Result.Success(new CommandResult(entityId: ObjectId.GenerateNewId().ToString())));
            _userServiceStub.UpdateUserNameAsync(Arg.Is<string>(arg => _operators.Select(o=>o.Id).Any(id => id == arg)), Arg.Any<string>()).Returns(args=> Result.Success(new CommandResult(entityId:(string)args[0])));
          
            _operators = GetOperatorsList();
            _operatorRepositoryStub = Substitute.For<IOperatorRepository>();
            _operatorRepositoryStub.CreateAsync(Arg.Any<Operator>()).Returns(args => AddNewOperator((Operator)args[0]));
            _operatorRepositoryStub.UpdateAsync(Arg.Is<Operator>(x => _operators.Any(u => u.Id == x.Id))).Returns(args => UpdateOperator((Operator)args[0]));
            _operatorRepositoryStub.GetByIdAsync(Arg.Is<string>(x => _operators.Any(u => u.Id == x))).Returns(args => _operators.First(u => u.Id == (string)args[0]));

            _operatorService = new OperatorService(_dummyInMemoryBus, _dummyIMapper, _dummyDomainNotificationHandler, _operatorRepositoryStub, _roleRepositoryStub, _userServiceStub);
        }



        private async Task AddNewOperator(Operator @operator)
        {
            _operators.Add(@operator);
        }



        private async Task UpdateOperator(Operator @operator)
        {
            var existOperator = _operators.FirstOrDefault(u => u.Id == @operator.Id);
            if (existOperator != null)
            {
                _operators.Remove(existOperator);
                _operators.Add(@operator);
            }
        }


        private List<Operator> GetOperatorsList()
        {
            return new List<Operator>
            {
                new Operator(ObjectId.GenerateNewId().ToString())
                {
                    Email="email_1@test.com",
                },
                 new Operator(ObjectId.GenerateNewId().ToString())
                {
                    Email="email_2@test.com",
                },
                  new Operator(ObjectId.GenerateNewId().ToString())
                {
                    Email="email_3@test.com",
                }
            };
        }



        #endregion
    }
}
