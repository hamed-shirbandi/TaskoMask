using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.UpdateTask
{
    public abstract class UpdateTaskValidation<TRequest> : AbstractValidator<TRequest> where TRequest : UpdateTaskRequest
    {
        public UpdateTaskValidation()
        {
            ValidateDescription();
        }


        private void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o => o.Title).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
        }
    }
}
