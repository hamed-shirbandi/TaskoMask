using FluentValidation;

namespace TaskoMask.Services.Identity.Api.UseCases.RegisterUser;

public sealed class RegisterUserValidation : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidation() { }
}
