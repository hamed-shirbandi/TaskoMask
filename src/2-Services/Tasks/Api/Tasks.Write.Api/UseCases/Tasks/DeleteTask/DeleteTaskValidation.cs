using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.DeleteTask;

public sealed class DeleteTaskValidation : AbstractValidator<DeleteTaskRequest>
{
    public DeleteTaskValidation() { }
}
