using FluentValidation;

namespace TaskoMask.Services.Identity.Api.UseCases.UpdateUser;

public sealed class UpdateUserValidation : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidation() { }
}
