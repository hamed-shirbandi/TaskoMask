using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Organization : BaseEntity
    {
        #region Properties


        public string Name { get; private set; }
        public string Description { get; private set; }
        public string UserId { get; private set; }


        #endregion


        #region Constructors


        public Organization(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
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