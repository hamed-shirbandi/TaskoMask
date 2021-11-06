using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Project : BaseEntity
    {
        #region Properties


        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }


        #endregion


        #region Constructors


        public Project(string name, string description, string organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }


        #endregion


        #region Main Methods


        public void SetName(string name)
        {
            Name = name;
        }


        public void SetDescription(string description)
        {
            Description = description;
        }


        #endregion
    }
}