using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.RegisterOwner;

public abstract class RegiserOwnerValidation<TRequest> : AbstractValidator<TRequest>
    where TRequest : RegiserOwnerRequest
{
    public RegiserOwnerValidation() { }
}
