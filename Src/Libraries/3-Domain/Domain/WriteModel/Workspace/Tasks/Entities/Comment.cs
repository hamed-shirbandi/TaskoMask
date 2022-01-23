using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.ValueObjects.Comments;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities
{
    /// <summary>
    /// Every board's member can leave comment on tasks
    /// </summary>
    public class Comment : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Comment(string content)
        {
            Content = CommentContent.Create(content);
            CheckPolicies();
        }

        #endregion

        #region Properties


        public CommentContent Content { get; private set; }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public static Comment Create(string content)
        {
            return new Comment(content);
        }




        /// <summary>
        /// 
        /// </summary>
        public void Update(string content)
        {
            Content = CommentContent.Create(content);
            base.UpdateModifiedDateTime();

            CheckPolicies();
        }



        /// <summary>
        /// 
        /// </summary>
        public new void Delete()
        {
            base.Delete();
            base.UpdateModifiedDateTime();

        }



        /// <summary>
        /// 
        /// </summary>
        public new void Recycle()
        {
            base.Recycle();
            base.UpdateModifiedDateTime();

        }
        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (Content == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Content)));
        }


        #endregion
    }
}
