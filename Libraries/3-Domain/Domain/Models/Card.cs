using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Card : BaseEntity
    {
        #region Properties


        public string Name { get; set; }
        public string Description { get; set; }
        public CardType Type { get; set; }
        public string BoardId { get; set; }


        #endregion


        #region Constructors


        public Card(string name, string description, string boardId, CardType type)
        {
            Name = name;
            Description = description;
            BoardId = boardId;
            Type = type;
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


        public void SetType(CardType type)
        {
            Type = type;
        }


        #endregion
    }
}