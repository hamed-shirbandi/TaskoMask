using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    public class Organization : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Organization(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;

            //example of using DomainException
            if (string.IsNullOrEmpty(UserId))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(userId)));

        }


        #endregion

        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string UserId { get; private set; }

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
