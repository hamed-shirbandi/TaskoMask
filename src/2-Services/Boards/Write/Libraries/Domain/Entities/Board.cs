using TaskoMask.BuildingBlocks.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.Services.Boards.Write.Domain.ValueObjects.Boards;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Boards.Write.Domain.Specifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Boards.Write.Domain.Services;
using TaskoMask.BuildingBlocks.Domain.Resources;
using MongoDB.Bson;
using TaskoMask.Services.Boards.Write.Domain.Events.Boards;
using TaskoMask.Services.Boards.Write.Domain.Events.Cards;

namespace TaskoMask.Services.Boards.Write.Domain.Entities
{
    public class Board: AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        private Board(string name, string description, string projectId, IBoardValidatorService boardValidatorService)
        {
            SetId(ObjectId.GenerateNewId().ToString());

            Name = BoardName.Create(name);
            Description = BoardDescription.Create(description);
            ProjectId = BoardProjectId.Create(projectId);
            Cards = new HashSet<Card>();
            
            CheckPolicies(boardValidatorService);
            AddDomainEvent(new BoardAddedEvent(Id, Name.Value, Description.Value, ProjectId.Value));
        }

        #endregion

        #region Properties

        public BoardName Name { get; private set; }
        public BoardDescription Description { get; private set; }
        public BoardProjectId ProjectId { get; private set; }
        public ICollection<Card> Cards { get; private set; }


        #endregion

        #region Board Behaviors




        /// <summary>
        /// 
        /// </summary>
        public static Board AddBoard(string name, string description, string projectId, IBoardValidatorService boardValidatorService)
        {
            return new Board(name, description, projectId, boardValidatorService);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateBoard(string name, string description, IBoardValidatorService boardValidatorService)
        {
            Name = BoardName.Create(name);
            Description = BoardDescription.Create(description);

            CheckPolicies(boardValidatorService);
            AddDomainEvent(new BoardUpdatedEvent(Id, Name.Value, Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteBoard()
        {
            AddDomainEvent(new BoardDeletedEvent(Id));
        }



        #endregion

        #region Card Behaviors



        /// <summary>
        /// 
        /// </summary>
        public void AddCard(Card card)
        {
            Cards.Add(card);
            AddDomainEvent(new CardAddedEvent(card.Id, card.Name.Value,card.Type.Value, Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateCard(string id, string name, BoardCardType type)
        {
            var card = Cards.FirstOrDefault(p => p.Id == id);
            if (card == null)
                throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Card));

            card.Update(name, type);

            AddDomainEvent(new CardUpdatedEvent(card.Id, card.Name.Value, card.Type.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteCard(string id)
        {
            var card = Cards.FirstOrDefault(p => p.Id == id);
            if (card == null)
                throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Card));

            Cards.Remove(card);
            AddDomainEvent(new CardDeletedEvent(card.Id));
        }


        /// <summary>
        /// 
        /// </summary>
        public Card GetCardById(string cardId)
        {
            var card = Cards.FirstOrDefault(p => p.Id == cardId);
            if (card == null)
                throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Card));

            return card;
        }


        #endregion

        #region Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies(IBoardValidatorService boardValidatorService)
        {
           
            if (Name == null)
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Name)));
           
            if (ProjectId == null)
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(ProjectId)));

            if (!new BoardNameAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);

            if (!new BoardNameMustUniqueSpecification(boardValidatorService).IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Board));

        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {
            if (!new BoardMaxCardsSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Max_Card_Count_Limitiation, DomainConstValues.Board_Max_Card_Count));
            
            if (!new CardNameMustUniqueSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Card));

        }



        #endregion
    }
}
