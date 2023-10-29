using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.UpdateOwnerProfile
{
    public abstract class UpdateOwnerProfileValidation<TRequest> : AbstractValidator<TRequest>
        where TRequest : UpdateOwnerProfileRequest
    {
        public UpdateOwnerProfileValidation() { }
    }
}
