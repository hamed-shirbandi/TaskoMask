using AutoMapper;
using TaskoMask.Application.Commands.Models.Users;
using TaskoMask.Application.Services.Users.Dto;
using TaskoMask.Application.ViewMoldes.Account;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Mapper
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

            CreateMap<User, UserOutput>();
            CreateMap<User, UserInput>();


            #endregion

            #region Dto To Dto

            CreateMap<UserOutput, UserInput>();


            #endregion

        }
    }
}
