using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Owners.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OwnersController : BaseApiController, IOwnerClientService
    {
        #region Fields

        private readonly IOwnerService _ownerService;

        #endregion

        #region Ctors

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get owner detail
        /// </summary>
        [HttpGet]
        [Route("owners/{id}")]
        public async Task<Result<OwnerDetailsViewModel>> Get(string id)
        {
            //TODO implement owner Get api
            return Result.Failure<OwnerDetailsViewModel>(message: "not implemented yet");
        }



        /// <summary>
        /// Add new owner to team
        /// </summary>
        [HttpPost]
        [Route("owners")]
        public async Task<Result<CommandResult>> Add(string email)
        {
            //TODO implement owners add api
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }



        /// <summary>
        /// remove a owner from team
        /// </summary>
        [HttpDelete]
        [Route("owners")]
        public async Task<Result<CommandResult>> Delete(string id )
        {
            //TODO implement owners Delete
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }


        #endregion

    }
}
