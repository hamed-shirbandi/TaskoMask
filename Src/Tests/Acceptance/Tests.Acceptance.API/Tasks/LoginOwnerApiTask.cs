using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest;
using Suzianna.Rest.OAuth;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;

namespace TaskoMask.Tests.Acceptance.API.Tasks
{
    public class LoginOwnerApiTask : LoginOwnerTask
    {
        public LoginOwnerApiTask(OwnerLoginDto ownerLoginDto) : base(ownerLoginDto)
        {

        }


        protected override bool DoLogin<T>(T actor)
        {
            actor.AttemptsTo(Post.DataAsJson(OwnerLoginDto).To("account/login"));
            var result = actor.AsksFor(LastResponse.Content<Result<UserJwtTokenDto>>());
            RememberAccessToken(actor, result);

            return result.IsSuccess;
        }



        /// <summary>
        /// By remembering the access token, It will automatically add to http headers for all next requests
        /// </summary>
        private void RememberAccessToken(Actor actor, Result<UserJwtTokenDto> result)
        {
            if (!result.IsSuccess)
                return;

            var token = new OAuthToken
            {
                AccessToken = result.Value.JwtToken,
                TokenType = TokenTypes.Bearer.ToString(),
            };
            actor.Remember(TokenConstants.TokenKey, token);
        }
    }
}
