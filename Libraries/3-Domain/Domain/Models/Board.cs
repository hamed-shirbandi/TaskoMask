using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Board : BaseEntity
    {
        #region Properties


        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }


        #endregion


        #region Constructors


        public Board(string name, string description, string projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
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