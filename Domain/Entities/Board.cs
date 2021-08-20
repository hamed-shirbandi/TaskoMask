using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Entities
{
    public class Board: BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Board(string name, string description, string projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }


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
