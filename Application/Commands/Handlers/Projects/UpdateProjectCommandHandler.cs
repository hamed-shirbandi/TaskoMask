using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Resources;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Projects
{
    public class UpdateProjectCommandHandler : CommandHandler, IRequestHandler<UpdateProjectCommand, Result<string>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMediator _mediator;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IMediator mediator) : base(mediator)
        {
            _projectRepository = projectRepository;
            _mediator = mediator;
        }

        public async Task<Result<string>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Result.Failure<string>(ApplicationMessages.Update_Failed);
            }

            //TODO check if name is exist and add error to DomainNotification

            var project = await _projectRepository.GetByIdAsync(request.Id);

            project.SetName(request.Name);
            project.SetDescription(request.Description);

            await _projectRepository.UpdateAsync(project);
            return Result.Success(ApplicationMessages.Update_Success);
        }
    }
}
