
using AutoMapper;
using Microsoft.Extensions.Configuration;
using TaskoMask.Application.Core.Dtos.Users;


namespace TaskoMask.Application.Mapper.MappingActions
{
    public class UserMappingAction : IMappingAction<BaseUser, UserInputDto>, IMappingAction<BaseUser, UserBasicInfoDto>
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
        public void Process(BaseUser source, UserInputDto destination, ResolutionContext context)
        {
        }



        /// <summary>
        /// 
        /// </summary>
        public void Process(BaseUser source, UserBasicInfoDto destination, ResolutionContext context)
        {
            destination.AvatarUrl = source.AvatarUrl.AddStaticSiteUrl(_configuration);
        }


        #endregion

        #region Private Methods



        #endregion
       
    }
}