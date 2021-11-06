using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Members.Services;
using TaskoMask.Application.Core.Dtos.Team.Members;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MembersController : BaseApiController
    {
        #region Fields

        private readonly IMemberService _memberService;

        #endregion

        #region Ctors

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get member detail
        /// </summary>
        [HttpGet]
        [Route("members/{id}")]
        public async Task<Result<MemberBasicInfoDto>> Get(string id)
        {
            return await _memberService.GetByIdAsync(id);
        }



        /// <summary>
        /// Add new member to team
        /// </summary>
        [HttpPost]
        [Route("members")]
        public async Task<Result<CommandResult>> Add(string email)
        {
            //TODO implement members add api
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }



        /// <summary>
        /// update member permissions
        /// </summary>
        [HttpPut]
        [Route("members")]
        public async Task<Result<CommandResult>> Update( )
        {
            //TODO implement members Update api
            return Result.Failure<CommandResult>(message:"not implemented yet");
        }



        /// <summary>
        /// remove a member from team
        /// </summary>
        [HttpDelete]
        [Route("members")]
        public async Task<Result<CommandResult>> Delete(string id )
        {
            //TODO implement members Delete
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }


        #endregion

    }
}
