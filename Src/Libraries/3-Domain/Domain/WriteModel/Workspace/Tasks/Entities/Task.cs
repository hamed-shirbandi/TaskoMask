using System.Collections.Generic;
using System.Linq;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Workspace.Tasks.Events.Activities;
using TaskoMask.Domain.Workspace.Tasks.Events.Comments;
using TaskoMask.Domain.Workspace.Tasks.Events.Tasks;
using TaskoMask.Domain.Workspace.Tasks.ValueObjects.Tasks;

namespace TaskoMask.Domain.Workspace.Tasks.Entities

{
    public class Task : AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        private Task(string title, string description, string cardId)
        {
            Title = TaskTitle.Create(title);
            Description = TaskDescription.Create(description);
            CardId = TaskCardId.Create(cardId);

            CheckPolicies();

            AddDomainEvent(new TaskCreatedEvent(Id, Title.Value, Description.Value, CardId.Value));
        }

        #endregion

        #region Properties

        public TaskTitle Title { get; private set; }
        public TaskDescription Description { get; private set; }
        public TaskCardId CardId { get; private set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Activity> Activities { get; set; }


        #endregion

        #region Public Task Methods




        /// <summary>
        /// 
        /// </summary>
        public static Task CreateTask(string title, string description, string cardId)
        {
            return new Task(title, description, cardId);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateTask(string name, string description)
        {
            Title = TaskTitle.Create(name);
            Description = TaskDescription.Create(description);

            base.UpdateModifiedDateTime();

            CheckPolicies();

            AddDomainEvent(new TaskUpdatedEvent(Id, Title.Value, Description.Value));

        }



        /// <summary>
        /// 
        /// </summary>
        public void MoveTaskToAnotherCard(string cardId)
        {
            CardId = TaskCardId.Create(cardId);
            base.UpdateModifiedDateTime();

            CheckPolicies();

            AddDomainEvent(new TaskMovedToAnotherCardEvent(Id, CardId.Value));

        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteTask()
        {
            base.Delete();
            AddDomainEvent(new TaskDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void RecycleTask()
        {
            base.Recycle();
            AddDomainEvent(new TaskRecycledEvent(Id));
        }



        #endregion

        #region Public Comment Methods



        /// <summary>
        /// 
        /// </summary>
        public void CreateComment(Comment comment)
        {
            Comments.Add(comment);
            AddDomainEvent(new CommentCreatedEvent(comment.Id, comment.Content.Value, Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateComment(string id, string content)
        {
            var comment = Comments.FirstOrDefault(p => p.Id == id);
            if (comment == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Comment));

            comment.Update(content);

            AddDomainEvent(new CommentUpdatedEvent(comment.Id, comment.Content.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteComment(string id)
        {
            var comment = Comments.FirstOrDefault(p => p.Id == id);
            if (comment == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Comment));

            comment.Delete();
            AddDomainEvent(new CommentDeletedEvent(comment.Id));
        }


        #endregion

        #region Public Activity Methods



        /// <summary>
        /// 
        /// </summary>
        public void CreateActivity(Activity activity)
        {
            Activities.Add(activity);
            AddDomainEvent(new ActivityCreatedEvent(activity.Id, activity.Description.Value, Id));
        }



        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (Description == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Description)));

            if (CardId == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(CardId)));

            if (Title == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Title)));

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
