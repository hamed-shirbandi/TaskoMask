using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
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
        #region Fields

        private readonly IProjectRepository _projectRepository;


        #endregion

        #region Ctors

        public ProjectsCommandHandlers(IProjectRepository projectRepository, IDomainNotificationHandler notifications) : base(notifications)
        {
            _projectRepository = projectRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (!IsValid(request))
                return new CommandResult(ApplicationMessages.Create_Failed);


            var exist = await _projectRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var project = new Project(name: request.Name, description: request.Description, organizationId: request.OrganizationId);
            if (!IsValid(project))
                return new CommandResult(ApplicationMessages.Create_Failed);

            await _projectRepository.CreateAsync(project);
            return new CommandResult(ApplicationMessages.Create_Success, project.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            if (!IsValid(request))
                return new CommandResult(ApplicationMessages.Update_Failed);


            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Project);


            var exist = await _projectRepository.ExistByNameAsync(project.Id, request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            project.Update(request.Name, request.Description);
            if (!IsValid(project))
                return new CommandResult(ApplicationMessages.Update_Failed);


            await _projectRepository.UpdateAsync(project);
            return new CommandResult(ApplicationMessages.Update_Success, project.Id);

        }


        #endregion

    }
}
