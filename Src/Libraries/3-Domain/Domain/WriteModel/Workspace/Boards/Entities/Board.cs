using TaskoMask.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Workspace.Boards.Events.Boards;
using TaskoMask.Domain.Workspace.Boards.ValueObjects.Boards;
using TaskoMask.Domain.Workspace.Boards.Events.Members;
using TaskoMask.Domain.Workspace.Boards.Events.Cards;
using TaskoMask.Domain.Share.Enums;

namespace TaskoMask.Domain.Workspace.Boards.Entities
{
    public class Board: AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        private Board(string name, string description, string cardId)
        {
            Name = BoardName.Create(name);
            Description = BoardDescription.Create(description);
            ProjectId = BoardProjectId.Create(cardId);

            AddDomainEvent(new BoardCreatedEvent(Id, name, description, cardId));
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
        public static Board CreateBoard(string name, string description, string cardId)
        {
            return new Board(name, description, cardId);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateBoard(string name, string description, string cardId )
        {
            Name = BoardName.Create(name);
            Description = BoardDescription.Create(description);
            ProjectId = BoardProjectId.Create(cardId);

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

        #region Public Card Methods



        /// <summary>
        /// 
        /// </summary>
        public void CreateCard(Card card)
        {
            Cards.Add(card);
            AddDomainEvent(new CardCreatedEvent(card.Id, card.Name, card.Description, Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateCard(string id, string name, string description)
        {
            var card = Cards.FirstOrDefault(p => p.Id == id);
            if (card == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Card));

            card.Update(name, description);

            AddDomainEvent(new CardUpdatedEvent(Id, Name.Value, Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteCard(string id)
        {
            var card = Cards.FirstOrDefault(p => p.Id == id);
            if (card == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Card));

            card.Delete();
            AddDomainEvent(new CardDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void RecycleCard(string id)
        {
            var card = Cards.FirstOrDefault(p => p.Id == id);
            if (card == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Card));

            card.Recycle();
            AddDomainEvent(new CardRecycledEvent(Id));
        }




        #endregion

        #region Public Member Methods



        /// <summary>
        /// 
        /// </summary>
        public void CreateMember(Member member)
        {
            Members.Add(member);
            AddDomainEvent(new MemberCreatedEvent(member.Id, member.MemberOwnerId, member.AccessLevel, Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateMember(string id, BoardMemberAccessLevel accessLevel )
        {
            var member = Members.FirstOrDefault(p => p.Id == id);
            if (member == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Member));

            member.Update(accessLevel);

            AddDomainEvent(new MemberUpdatedEvent(Id, Name.Value, Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteMember(string id)
        {
            var member = Members.FirstOrDefault(p => p.Id == id);
            if (member == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Member));

            member.Delete();
            AddDomainEvent(new MemberDeletedEvent(Id));
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
