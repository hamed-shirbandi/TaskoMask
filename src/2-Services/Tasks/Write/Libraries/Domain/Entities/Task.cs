using System.Collections.Generic;
using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Domain.Events.Comments;
using TaskoMask.Services.Tasks.Write.Domain.Events.Tasks;
using TaskoMask.Services.Tasks.Write.Domain.Services;
using TaskoMask.Services.Tasks.Write.Domain.Specifications;
using TaskoMask.Services.Tasks.Write.Domain.ValueObjects.Tasks;
using TaskoMask.BuildingBlocks.Domain.Resources;
using MongoDB.Bson;
using System;

namespace TaskoMask.Services.Tasks.Write.Domain.Entities

{
    public class Task : AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        private Task(string title, string description, string cardId,string boardId, ITaskValidatorService taskValidatorService)
        {
            SetId(ObjectId.GenerateNewId().ToString());

            Title = TaskTitle.Create(title);
            Description = TaskDescription.Create(description);
            CardId = TaskCardId.Create(cardId);
            BoardId = TaskBoardId.Create(boardId);
            Comments = new HashSet<Comment>();

            CheckPolicies(taskValidatorService);

            AddDomainEvent(new TaskAddedEvent(Id, Title.Value, Description.Value, CardId.Value,BoardId.Value));
        }

        #endregion

        #region Properties

        public TaskTitle Title { get; private set; }
        public TaskDescription Description { get; private set; }
        public TaskBoardId BoardId { get; private set; }
        public TaskCardId CardId { get; private set; }
        public ICollection<Comment> Comments { get; private set; }


        #endregion

        #region Public Task Methods




        /// <summary>
        /// 
        /// </summary>
        public static Task AddTask(string title, string description, string cardId, string boardId, ITaskValidatorService taskValidatorService)
        {
            return new Task(title, description, cardId, boardId, taskValidatorService);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateTask(string title, string description, ITaskValidatorService taskValidatorService)
        {
            Title = TaskTitle.Create(title);
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
            AddDomainEvent(new TaskDeletedEvent(Id));
        }


        #endregion

        #region Public Comment Methods



        /// <summary>
        /// 
        /// </summary>
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
            AddDomainEvent(new CommentAddedEvent(comment.Id, comment.Content.Value, Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateComment(string id, string content)
        {
            var comment = Comments.FirstOrDefault(p => p.Id == id);
            if (comment == null)
                throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Comment));

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
                throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Comment));

            Comments.Remove(comment);
            AddDomainEvent(new CommentDeletedEvent(comment.Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public Comment GetCommentById(string commentId)
        {
            var comment = Comments.FirstOrDefault(p => p.Id == commentId);
            if (comment == null)
                throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Comment));

            return comment;
        }

        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies(ITaskValidatorService taskValidatorService)
        {
          
            if (CardId == null)
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(CardId)));

            if (Title == null)
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Title)));

            if (!new TaskTitleAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);

            if (!new TaskTitleMustUniqueSpecification(taskValidatorService).IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Task));
           
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
