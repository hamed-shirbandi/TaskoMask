using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.Domain.Entities
{
    public class UserToken : IdentityUserToken<string>
    {
        public UserToken()
        {
            
        }
    }
}
