using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.Api.Domain.Entities;

public class User : IdentityUser<string>
{
    public User(string id)
    {
        Id = id;
    }

    public bool IsActive { get; set; }
}
