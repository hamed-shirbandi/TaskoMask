using TaskoMask.Domain.TaskManagement.Events;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.TaskManagement.Entities
{
    public class Board: BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Board(string name, string description, string projectId, string organizationId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
            OrganizationId = organizationId;

            AddDomainEvent(new BoardCreatedEvent(Id, name, description, projectId, organizationId));

        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }
        public string OrganizationId { get; private set; }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Update(string name, string description)
        {
            Description = description;
            Name = name;
            base.Update();

        }



        #endregion

        #region Private Methods



        #endregion
    }
}
