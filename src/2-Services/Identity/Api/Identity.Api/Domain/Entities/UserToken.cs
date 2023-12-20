using Microsoft.AspNetCore.Identity;

namespace TaskoMask.Services.Identity.Api.Domain.Entities;

public class UserToken : IdentityUserToken<string>
{
    public UserToken() { }
}
