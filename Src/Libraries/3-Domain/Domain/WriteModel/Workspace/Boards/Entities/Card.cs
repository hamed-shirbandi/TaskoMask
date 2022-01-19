using TaskoMask.Domain.Workspace.Boards.Events;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Workspace.Boards.Entities
{
    public class Card : AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        public Card(string name, string description, string boardId, BoardCardType type, string organizationId, string projectId)
        {
            Name = name;
            Description = description;
            BoardId = boardId;
            ProjectId = projectId;
            OrganizationId = organizationId;
            Type = type;

            AddDomainEvent(new CardCreatedEvent(Id, name, description, boardId, projectId, organizationId));
        }

        #endregion

        #region Properties


        public string Name { get; set; }
        public string Description { get; set; }
        public BoardCardType Type { get; set; }
        public string BoardId { get; set; }
        public string ProjectId { get; private set; }
        public string OrganizationId { get; private set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Update(string name, string description, BoardCardType type)
        {
            Name = name;
            Type = type;
            Description = description;
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
