using TaskoMask.Domain.Administration.Events;
using TaskoMask.Domain.Core.Models;


namespace TaskoMask.Domain.Administration.Entities
{
    /// <summary>
    /// operator's role
    /// </summary>
   public class Role : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Role(string name, string description)
        {
            Name = name;
            Description = description;

            AddDomainEvent(new RoleCreatedEvent(Id,name,description));
        }



        #endregion

        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }

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
