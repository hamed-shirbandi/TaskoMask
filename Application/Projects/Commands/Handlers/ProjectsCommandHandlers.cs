using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Application.Projects.Commands.Handlers
{
    public class ProjectsCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateProjectCommand, CommandResult>,
         IRequestHandler<UpdateProjectCommand, CommandResult>
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectsCommandHandlers(IProjectRepository projectRepository, IMediator mediator, IDomainNotificationHandler notifications) : base(mediator, notifications)
        {
            _projectRepository = projectRepository;
        }


        public async Task<CommandResult> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                PublishValidationError(request);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var existOrganizationId = true;
            if (!existOrganizationId)
                throw new ApplicationException(string.Format(ApplicationMessages.Invalid_ForeignKey, nameof(request.OrganizationId)));



            var exist = await _projectRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                PublishValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var project = new Project(name: request.Name, description: request.Description, organizationId: request.OrganizationId);
            if (_notifications.HasAny())
                return new CommandResult(ApplicationMessages.Create_Failed);

            await _projectRepository.CreateAsync(project);
            return new CommandResult(ApplicationMessages.Create_Success,project.Id);

        }




        public async Task<CommandResult> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                PublishValidationError(request);
                return new CommandResult(ApplicationMessages.Update_Failed,request.Id);
            }



            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Project);


            var exist = await _projectRepository.ExistByNameAsync(project.Id, request.Name);
            if (exist)
            {
                PublishValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed,request.Id);
            }

            project.Update(request.Name, request.Description);
        
            if (_notifications.HasAny())
                return new CommandResult(ApplicationMessages.Update_Failed);


            await _projectRepository.UpdateAsync(project);
            return new CommandResult(ApplicationMessages.Update_Success,project.Id);

        }

    }
}
