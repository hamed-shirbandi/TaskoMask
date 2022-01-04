using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Team.Entities
{
    public class Project : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Project(string name, string description, string organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }

      
        #endregion

        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }


        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public void Update(string name, string description, string organizationId)
        {
            OrganizationId = organizationId;
            Description = description;
            Name = name;
            base.Update();
        }


        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {

        }


        #endregion


    }
}
