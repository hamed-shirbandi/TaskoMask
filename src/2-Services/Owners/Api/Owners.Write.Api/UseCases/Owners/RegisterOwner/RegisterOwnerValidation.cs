using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.RegisterOwner;

public sealed class RegiserOwnerValidation : AbstractValidator<RegiserOwnerRequest>
{
    public RegiserOwnerValidation() { }
}
