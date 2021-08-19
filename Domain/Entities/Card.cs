using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.Card), ResourceType = typeof(DomainMetadata))]
    public class Card : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Card(string name, string description, string boardId, CardType type)
        {
            Name = name;
            Description = description;
            BoardId = boardId;
            Type = type;
        }

        #endregion

        #region Properties


        public string Name { get; set; }
        public string Description { get; set; }
        public CardType Type { get; set; }
        public string BoardId { get; set; }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Update(string name, string description, CardType type)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        #endregion

        #region Private Methods



        #endregion
      


    }
}
