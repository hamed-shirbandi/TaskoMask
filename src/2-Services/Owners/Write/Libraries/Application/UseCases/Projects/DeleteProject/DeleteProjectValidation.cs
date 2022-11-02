using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Projects.DeleteProject
{
    public abstract class DeleteProjectValidation<TRequest> : AbstractValidator<TRequest> where TRequest : DeleteProjectRequest
    {
        public DeleteProjectValidation()
        {
        }

    }
}
