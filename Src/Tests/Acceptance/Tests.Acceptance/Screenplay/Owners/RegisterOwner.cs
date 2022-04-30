﻿using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Helpers;
using TaskoMask.Tests.Acceptance.Models.Owners;

namespace TaskoMask.Tests.Acceptance.Screenplay.Owners
{
    public class RegisterOwner : ITask
    {
        private readonly OwnerRegisterDto _ownerRegisterDto;

        public RegisterOwner(OwnerRegisterDto ownerRegisterDto)
        {
            _ownerRegisterDto = ownerRegisterDto;
        }


        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Post.DataAsJson(_ownerRegisterDto).To("account/login"));
            var result = actor.AsksFor(LastResponse.Content<Result<UserJwtTokenDto>>());
            actor.Remember(MagicKey.Owner.Regiser_Result, result);
        }
    }
}
