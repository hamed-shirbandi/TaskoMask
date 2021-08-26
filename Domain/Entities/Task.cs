using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Entities
{
    public class Task : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Task(string title, string description, string cardId)
        {
            Title = title;
            Description = description;
            CardId = cardId;
        }

        #endregion

        #region Properties

        public string Title { get; set; }
        public string Description { get; set; }
        public string CardId { get; set; }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public void Update(string title, string description)
        {
            Description = description;
            Title = title;
            base.Update();
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
