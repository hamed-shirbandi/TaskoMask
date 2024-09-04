using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.UpdateOwnerProfile;

public sealed class UpdateOwnerProfileValidation : AbstractValidator<UpdateOwnerProfileRequest>
{
    public UpdateOwnerProfileValidation() { }
}
