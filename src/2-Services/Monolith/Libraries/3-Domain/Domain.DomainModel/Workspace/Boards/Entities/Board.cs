using TaskoMask.Services.Monolith.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Services.Monolith.Domain.Share.Resources;
using TaskoMask.Services.Monolith.Domain.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Boards;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.ValueObjects.Boards;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Members;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Cards;
using TaskoMask.Services.Monolith.Domain.Share.Enums;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Specifications;
using TaskoMask.Services.Monolith.Domain.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities
{
    public class Board: AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        private Board(string name, string description, string projectId, IBoardValidatorService boardValidatorService)
        {
            Name = BoardName.Create(name);
            Description = BoardDescription.Create(description);
            ProjectId = BoardProjectId.Create(projectId);
            Cards = new HashSet<Card>();
            Members = new HashSet<Member>();
            
            CheckPolicies(boardValidatorService);
            AddDomainEvent(new BoardAddedEvent(Id, Name.Value, Description.Value, ProjectId.Value));
        }

        #endregion

        #region Properties

        public BoardName Name { get; private set; }
        public BoardDescription Description { get; private set; }
        public BoardProjectId ProjectId { get; private set; }
        public ICollection<Card> Cards { get; private set; }
        public ICollection<Member> Members { get; private set; }


        #endregion

        #region Public Board Methods




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

        #region Public Card Methods



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
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Card));

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
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Card));

            Cards.Remove(card);
            AddDomainEvent(new CardDeletedEvent(card.Id));
        }


        #endregion

        #region Public Member Methods



        /// <summary>
        /// 
        /// </summary>
        public void AddMember(Member member)
        {
            Members.Add(member);
            AddDomainEvent(new MemberAddedEvent(member.Id, member.OwnerId.Value, member.AccessLevel.Value, Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateMemberAccessLevel(string id, BoardMemberAccessLevel accessLevel )
        {
            var member = Members.FirstOrDefault(p => p.Id == id);
            if (member == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Member));

            member.Update(accessLevel);

            AddDomainEvent(new MemberAccessLevelUpdatedEvent(member.Id, member.AccessLevel.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteMember(string id)
        {
            var member = Members.FirstOrDefault(p => p.Id == id);
            if (member == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Member));

            Members.Remove(member);
            AddDomainEvent(new MemberDeletedEvent(member.Id));
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies(IBoardValidatorService boardValidatorService)
        {
           
            if (Name == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Name)));
           
            if (ProjectId == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(ProjectId)));

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
            
            if (!new BoardMaxMembersSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Max_Member_Count_Limitiation, DomainConstValues.Board_Max_Member_Count));

            if (!new CardNameMustUniqueSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Card));

            if (!new MemberOwnerIdMustUniqueSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Member));
        }



        #endregion
    }
}
