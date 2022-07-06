using System.Collections.Generic;
using System.Linq;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Activities;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Comments;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Tasks;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Services;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.ValueObjects.Tasks;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities

{
    public class Task : AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        private Task(string title, string description, string cardId,string boardId, ITaskValidatorService taskValidatorService)
        {
            Title = TaskTitle.Create(title);
            Description = TaskDescription.Create(description);
            CardId = TaskCardId.Create(cardId);
            BoardId = TaskBoardId.Create(boardId);
            Comments = new HashSet<Comment>();
            Activities = new HashSet<Activity>();

            CheckPolicies(taskValidatorService);

            AddDomainEvent(new TaskCreatedEvent(Id, Title.Value, Description.Value, CardId.Value,BoardId.Value));
        }

        #endregion

        #region Properties

        public TaskTitle Title { get; private set; }
        public TaskDescription Description { get; private set; }
        public TaskBoardId BoardId { get; private set; }
        public TaskCardId CardId { get; private set; }
        public ICollection<Comment> Comments { get; private set; }
        public ICollection<Activity> Activities { get; private set; }


        #endregion

        #region Public Task Methods




        /// <summary>
        /// 
        /// </summary>
        public static Task CreateTask(string title, string description, string cardId, string boardId, ITaskValidatorService taskValidatorService)
        {
            return new Task(title, description, cardId, boardId, taskValidatorService);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateTask(string name , string description, ITaskValidatorService taskValidatorService)
        {
            Title = TaskTitle.Create(name);
            Description = TaskDescription.Create(description);

            CheckPolicies(taskValidatorService);

            AddDomainEvent(new TaskUpdatedEvent(Id, Title.Value, Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void MoveTaskToAnotherCard(string cardId)
        {
            CardId = TaskCardId.Create(cardId);
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
        private void CheckPolicies(ITaskValidatorService taskValidatorService)
        {
            if (Description == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Description)));

            if (CardId == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(CardId)));

            if (Title == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Title)));

            if (!new TaskTitleAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);

            if (!new TaskTitleMustUniqueSpecification(taskValidatorService).IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Organization));
           
            if (!new MaxTasksSpecification(taskValidatorService).IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Max_Task_Count_Limitiation, DomainConstValues.Board_Max_Task_Count));
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
