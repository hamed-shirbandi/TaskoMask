using TaskoMask.Services.Identity.Api.Domain.Entities;

namespace TaskoMask.Services.Identity.Tests.Unit.TestData;

internal class UserBuilder
{
    public string Id { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    public bool IsActive { get; private set; }
    public string Password { get; private set; }

    private UserBuilder() { }

    public static UserBuilder Init()
    {
        return new UserBuilder();
    }

    public UserBuilder WithId(string id)
    {
        Id = id;
        return this;
    }

    public UserBuilder WithEmail(string email)
    {
        Email = email;
        return this;
    }

    public UserBuilder WithUserName(string userName)
    {
        UserName = userName;
        return this;
    }

    public UserBuilder WithIsActive(bool isActive)
    {
        IsActive = isActive;
        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        Password = password;
        return this;
    }

    public User Build()
    {
        return new User(Id)
        {
            UserName = UserName,
            Email = Email,
            IsActive = IsActive,
            PasswordHash = Password,
        };
    }
}
