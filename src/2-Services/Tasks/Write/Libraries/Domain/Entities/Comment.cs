using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Domain.ValueObjects.Comments;
using MongoDB.Bson;

namespace TaskoMask.Services.Tasks.Write.Domain.Entities
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
            SetId(ObjectId.GenerateNewId().ToString());

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


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (Content == null)
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Content)));
        }


        #endregion
    }
}
