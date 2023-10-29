using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Services;

namespace TaskoMask.Services.Owners.Write.Tests.Base.TestData;

public class OwnerBuilder
{
    public IOwnerValidatorService ValidatorService { get; private set; }
    public string Email { get; private set; }
    public string DisplayName { get; private set; }

    private OwnerBuilder() { }

    public static OwnerBuilder Init()
    {
        return new OwnerBuilder();
    }

    public OwnerBuilder WithValidatorService(IOwnerValidatorService validatorService)
    {
        ValidatorService = validatorService;
        return this;
    }

    public OwnerBuilder WithEmail(string email)
    {
        Email = email;
        return this;
    }

    public OwnerBuilder WithDisplayName(string displayName)
    {
        DisplayName = displayName;
        return this;
    }

    public Owner Build()
    {
        var owner = Owner.RegisterOwner(DisplayName, Email, ValidatorService);
        owner.ClearDomainEvents();
        return owner;
    }
}
