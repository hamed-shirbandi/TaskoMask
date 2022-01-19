using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.ReadModel.Entities
{
    /// <summary>
    /// Every board's member can leave comment on tasks
    /// </summary>
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

    }
}
