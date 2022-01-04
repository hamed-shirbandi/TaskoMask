using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Workspace.Entities
{
    public class Task : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Task(string title, string description, string cardId, string boardId, string organizationId, string projectId)
        {
            Title = title;
            Description = description;
            CardId = cardId;
            BoardId = boardId;
            ProjectId = projectId;
            OrganizationId = organizationId;
        }

        #endregion

        #region Properties

        public string Title { get; set; }
        public string Description { get; set; }
        public string CardId { get; set; }
        public string BoardId { get; set; }
        public string ProjectId { get; private set; }
        public string OrganizationId { get; private set; }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public void Update(string title, string description)
        {
            Description = description;
            Title = title;
            base.Update();
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
