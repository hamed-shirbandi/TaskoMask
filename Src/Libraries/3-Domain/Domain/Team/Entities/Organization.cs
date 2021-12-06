using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Team.Events;

namespace TaskoMask.Domain.Team.Entities
{
    public class Organization : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Organization(string name, string description, string ownerMemberId)
        {
            Name = name;
            Description = description;
            OwnerMemberId = ownerMemberId;

            //example of using DomainException
            if (string.IsNullOrEmpty(OwnerMemberId))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(ownerMemberId)));

            AddDomainEvent(new OrganizationCreatedEvent(Id, name, description, ownerMemberId));

        }


        #endregion

        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string OwnerMemberId { get; private set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Update(string name, string description)
        {
            Description = description;
            Name = name;
            base.Update();

        }



        #endregion

        #region Private Methods



        #endregion

    }
}
