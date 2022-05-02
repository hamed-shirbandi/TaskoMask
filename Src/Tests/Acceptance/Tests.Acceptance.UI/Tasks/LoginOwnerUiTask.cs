using TaskoMask.Tests.Acceptance.Share.Models;
using Tests.Acceptance.Share.Screenplay.Tasks;

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
