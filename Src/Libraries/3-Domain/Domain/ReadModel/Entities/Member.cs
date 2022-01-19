
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    /// <summary>
    /// Member of a board
    /// </summary>
    public class Member : BaseEntity
    {
        /// <summary>
        /// Each member is an owner at the first
        /// This is a foreign key to Owner
        /// </summary>
        public string OwnerId { get; set; }

        public string AccessLevel { get; set; }
    }

}
