using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.Api.Domain.Entities;

public class UserLogin : IdentityUserLogin<string>
{
    public UserLogin() { }
}
