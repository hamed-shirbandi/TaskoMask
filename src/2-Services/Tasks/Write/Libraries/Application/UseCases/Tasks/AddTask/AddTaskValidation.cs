using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.AddTask
{
    public abstract class AddTaskValidation<TRequest> : AbstractValidator<TRequest> where TRequest : AddTaskRequest
    {
        public AddTaskValidation()
        {
            ValidateDescription();
        }


        private void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o => o.Title).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
        }
    }
}
