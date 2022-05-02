using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using System;
using TaskoMask.Tests.Acceptance.Share.Models;
using TaskoMask.Tests.Acceptance.Share.Screenplay.Tasks;

namespace TaskoMask.Tests.Acceptance.UI.Tasks
{
    public class RegisterOwnerUiTask : RegisterOwnerTask
    {
        public RegisterOwnerUiTask(OwnerRegisterDto ownerRegisterDto):base(ownerRegisterDto)
        {

        }


        protected override bool DoRegister<T>(T actor)
        {
            throw new NotImplementedException();
        }
    }
}
