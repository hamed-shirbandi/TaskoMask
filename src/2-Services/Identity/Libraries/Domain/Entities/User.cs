using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.Domain.Entities
{
   public class User : IdentityUser<string>
    {
        public User(string id)
        {
            Id= id;
        }

        public bool IsActive { get; set; }
    }
}
