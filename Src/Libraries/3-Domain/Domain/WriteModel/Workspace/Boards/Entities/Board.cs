using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Workspace.Boards.Board.ValueObjects;
using System.Collections.Generic;
using TaskoMask.Domain.Workspace.Boards.Board.Events;

namespace TaskoMask.Domain.Workspace.Boards.Entities
{
    public class Board: AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        private Board(string name, string description, string projectId)
        {
            Name = BoardName.Create(name);
            Description = BoardDescription.Create(description);
            ProjectId = BoardProjectId.Create(projectId);

            AddDomainEvent(new BoardCreatedEvent(Id, name, description, projectId));
        }

        #endregion

        #region Properties

        public BoardName Name { get; private set; }
        public BoardDescription Description { get; private set; }
        public BoardProjectId ProjectId { get; private set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Member> Members { get; set; }


        #endregion

        #region Public Board Methods




        /// <summary>
        /// 
        /// </summary>
        public static Board CreateBoard(string name, string description, string projectId)
        {
            return new Board(name, description, projectId);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateBoard(string name, string description, string projectId )
        {
            Name = BoardName.Create(name);
            Description = BoardDescription.Create(description);
            ProjectId = BoardProjectId.Create(projectId);

            base.UpdateModifiedDateTime();

            CheckPolicies();

            AddDomainEvent(new BoardUpdatedEvent(Id, Name.Value, Description.Value));

        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteBoard()
        {
            base.Delete();
            AddDomainEvent(new BoardDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void RecycleBoard()
        {
            base.Recycle();
            AddDomainEvent(new BoardRecycledEvent(Id));
        }



        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {

        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {

        }



        #endregion
    }
}
