using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.BuildingBlocks.Domain.Models
{

    /// <summary>
    ///
    /// </summary>
    public abstract class BaseEntity
    {
        #region Ctors

        public BaseEntity()
        {
            CreationTime = CreationTime.Create();
        }


        #endregion

        #region Properties

        public string Id { get; private set; }
        public CreationTime CreationTime { get; private set; }



        #endregion

        #region Public Methods





        #endregion


        #region protected Methods


        /// <summary>
        /// 
        /// </summary>
        protected void UpdateModifiedDateTime()
        {
            CreationTime = CreationTime.UpdateModifiedDateTime();
        }



        /// <summary>
        /// 
        /// </summary>
        protected void SetId(string id)
        {
            Id = id;
        }




        #endregion

    }
}
