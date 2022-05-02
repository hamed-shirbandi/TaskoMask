using System;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;

namespace TaskoMask.Tests.Acceptance.UI.Tasks
{
    public class LoginOwnerUiTask : LoginOwnerTask
    {
        public LoginOwnerUiTask(OwnerLoginDto ownerLoginDto):base(ownerLoginDto)
        {

        }


        protected override bool DoLogin<T>(T actor)
        {
            throw new NotImplementedException();
        }
    }
}
