using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.Domain.Entities
{
   public class User : IdentityUser<string>
    {
        public User()
        {

        }

        public bool IsActive { get; set; }
    }
}
