using MongoDB.Bson;
using TaskoMask.Domain.Core.ValueObjects;

namespace TaskoMask.Domain.Core.Models
{

    /// <summary>
    ///
    /// </summary>
    public abstract class BaseEntity
    {
        #region Ctors

        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId().ToString();
            CreationTime = CreationTime.Create();
        }


        #endregion

        #region Properties

        public string Id { get; private set; }
        public bool IsDeleted { get; private set; }
        public CreationTime CreationTime { get; private set; }



        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public virtual void SetId(string id)
        {
            Id = id;
            UpdateModifiedDateTime();
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void SoftDelete()
        {
            IsDeleted = true;
            UpdateModifiedDateTime();
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual void Recycle()
        {
            IsDeleted = false;
            UpdateModifiedDateTime();
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual void UpdateModifiedDateTime()
        {
            CreationTime = CreationTime.UpdateModifiedDateTime();
        }


        #endregion


        #region Private Methods



        #endregion

    }
}
