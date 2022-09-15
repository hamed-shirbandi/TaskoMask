using FluentValidation;
using TaskoMask.Services.Identity.Application.Resources;

namespace TaskoMask.Services.Identity.Application.UseCases.UserLogin
{
    public abstract class UserLoginValidation<TRequest> : AbstractValidator<TRequest> where TRequest : UserLoginRequest
    {
        public UserLoginValidation()
        {
            ValidateReturnUrl();
        }

        protected void ValidateReturnUrl()
        {
            RuleFor(x => x.ReturnUrl).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.ReturnUrl)).WithMessage(ApplicationMessages.InvalidReturnUrl);
        }
    }
}
