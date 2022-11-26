using MediatR;
using System.Threading;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Projects;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class ProjectEventHandles : 
        INotificationHandler<ProjectAddedEvent>,
        INotificationHandler<ProjectUpdatedEvent>,
        INotificationHandler<ProjectDeletedEvent>
    {
        #region Fields

        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Ctors

        public ProjectEventHandles(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(ProjectAddedEvent addedProject, CancellationToken cancellationToken)
        {

            var project = new Project(addedProject.Id)
            {
                Name= addedProject.Name,
                Description= addedProject.Description,
                OrganizationId= addedProject.OrganizationId,
                OwnerId = addedProject.OwnerId,
            };
           await _projectRepository.AddAsync(project);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(ProjectUpdatedEvent updatedProject, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(updatedProject.Id);

            project.Name = updatedProject.Name;
            project.Description = updatedProject.Description;

            project.SetAsUpdated();

            await _projectRepository.UpdateAsync(project);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(ProjectDeletedEvent deletedProject, CancellationToken cancellationToken)
        {
            await _projectRepository.DeleteAsync(deletedProject.Id);
        }



        #endregion

    }
}
