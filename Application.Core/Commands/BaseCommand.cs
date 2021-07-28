using TaskoMask.Application.Core.Helpers;
using FluentValidation.Results;
using MediatR;
using System.Linq;
using System.Text.Json.Serialization;
using TaskoMask.Application.Core.Extensions;

namespace TaskoMask.Application.Core.Commands
{
    public abstract class BaseCommand : IRequest<CommandResult>
    {
        #region Properties


        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; }


        #endregion


        #region Public Methods => Validation


        public virtual bool IsValid()
        {
            ValidationResult = new BaseCommandValidation().Validate(this); //Fluent Validation

            GetAnnotationValidation();

            return ValidationResult.IsValid;
        }


        #endregion


        #region Private Methods


        protected void GetAnnotationValidation()
        {
            if (this.Validate(out var results))
                return;
            foreach (var result in results)
                ValidationResult.Errors.Add(
                    new ValidationFailure(result.MemberNames.FirstOrDefault(), result.ErrorMessage));
        }


        #endregion
    }
}