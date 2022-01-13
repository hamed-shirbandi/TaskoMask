using TaskoMask.Domain.Workspace.Boards.Events;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Workspace.Boards.Entities
{
    public class Board: BaseAggregate
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
        public void Update(string name, string description, string projectId, string organizationId)
        {
            Description = description;
            Name = name;
            ProjectId = projectId;
            OrganizationId = organizationId;

            base.UpdateModifiedDateTime();

        }



        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {

        }



        #endregion
    }
}
