using MediatR;
using System.Threading;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Projects;

namespace TaskoMask.Application.Workspace.Projects.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class ProjectEventHandles : 
        INotificationHandler<ProjectCreatedEvent>,
        INotificationHandler<ProjectUpdatedEvent>,
        INotificationHandler<ProjectDeletedEvent>,
        INotificationHandler<ProjectRecycledEvent>
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
        public async System.Threading.Tasks.Task Handle(ProjectCreatedEvent createdProject, CancellationToken cancellationToken)
        {
            var project = new Project(createdProject.Id)
            {
                Name= createdProject.Name,
                Description= createdProject.Description,
                OrganizationId= createdProject.OrganizationId,
            };
           await _projectRepository.CreateAsync(project);
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
            var project = await _projectRepository.GetByIdAsync(deletedProject.Id);
            project.SetAsDeleted();
            await _projectRepository.UpdateAsync(project);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(ProjectRecycledEvent recycledProject, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(recycledProject.Id);
            project.SetAsRecycled();
            await _projectRepository.UpdateAsync(project);
        }

        #endregion






    }
}
