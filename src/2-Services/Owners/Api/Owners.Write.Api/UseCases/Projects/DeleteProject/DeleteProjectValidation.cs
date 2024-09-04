using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.DeleteProject;

public sealed class DeleteProjectValidation : AbstractValidator<DeleteProjectRequest>
{
    public DeleteProjectValidation() { }
}
