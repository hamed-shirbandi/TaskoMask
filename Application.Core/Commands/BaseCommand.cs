using TaskoMask.Application.Core.Helpers;
using FluentValidation.Results;
using MediatR;
using System.Linq;
using System.Text.Json.Serialization;
using TaskoMask.Application.Core.Extensions;
using FluentValidation;

namespace TaskoMask.Application.Core.Commands
{
    public abstract class BaseCommand : IRequest<CommandResult>
    {
        #region Properties


        public ValidationResult ValidationResult { get; protected set; }


        #endregion


        #region Public Methods 

        /// <summary>
        /// validating command models must validate fluent and data annotation validation
        /// command models can have both or one of validation types (fluent - data annotation)
        /// </summary>
        public virtual bool IsValid()
        {
            //Step1: Check if caller has no fluent validation and init ValidationResult for Sterp 2 
            if (ValidationResult==null)
                ValidationResult = new BaseCommandValidation().Validate(this);

            //Sterp 2: Add data annotation validation to ValidationResult
            GetAnnotationValidation();


            return ValidationResult.IsValid;
        }




        #endregion


        #region Private Methods


        protected void GetAnnotationValidation()
        {
            //try validate data annotations 
            if (this.Validate(out var results))
                return;

            //add data annotation validations to ValidationResult
            foreach (var result in results)
                ValidationResult.Errors.Add(new ValidationFailure(result.MemberNames.FirstOrDefault(), result.ErrorMessage));
        }


        #endregion
    }
}