using AutoMapper;
using TaskoMask.Application.Users.Commands.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.ViewMoldes.Account;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Mapper.MappingActions;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            #region ViewModel To Command

            CreateMap<RegisterViewModel, CreateUserCommand>()
              .ConstructUsing(c => new CreateUserCommand(c.DisplayName, c.Email,c.Password));

            #endregion

            #region Dto To Command

            //CreateMap<UserInput, CreateUserCommand>()
            //  .ConstructUsing(c => new CreateUserCommand(c.DisplayName,c.Email));

            CreateMap<UserInput, UpdateUserCommand>()
              .ConstructUsing(c => new UpdateUserCommand(c.Id, c.DisplayName,c.Email));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateUserCommand, User>()
             .ConstructUsing(c => new User(c.DisplayName.Trim(),c.Email,c.Email));

            #endregion

            #region Domain Model To Dto

            CreateMap<User, UserOutput>().AfterMap<UserMappingAction>();
            CreateMap<User, UserInput>().AfterMap<UserMappingAction>();


            #endregion

            #region Dto To Dto

            CreateMap<UserOutput, UserInput>();


            #endregion

        }
    }
}
