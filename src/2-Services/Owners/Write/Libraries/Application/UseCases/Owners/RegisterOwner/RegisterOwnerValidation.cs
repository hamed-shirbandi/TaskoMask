using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner
{
    public abstract class RegiserOwnerValidation<TRequest> : AbstractValidator<TRequest> where TRequest : RegiserOwnerRequest
    {
        public RegiserOwnerValidation()
        {
        }

    }
}
