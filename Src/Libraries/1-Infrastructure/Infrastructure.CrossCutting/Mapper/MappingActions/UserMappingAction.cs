
using AutoMapper;
using Microsoft.Extensions.Configuration;
using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Mapper.MappingActions
{
    public class UserMappingAction : IMappingAction<UserAuthentication, UserUpsertDto>, IMappingAction<UserAuthentication, UserBasicInfoDto>
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Ctors

        public UserMappingAction(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public void Process(UserAuthentication source, UserUpsertDto destination, ResolutionContext context)
        {
        }



        /// <summary>
        /// 
        /// </summary>
        public void Process(UserAuthentication source, UserBasicInfoDto destination, ResolutionContext context)
        {
            destination.AvatarUrl = source.AvatarUrl.AddStaticSiteUrl(_configuration);
        }


        #endregion

        #region Private Methods



        #endregion
       
    }
}