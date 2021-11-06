
using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Core.Enums
{


    /// <summary>
    /// 
    /// </summary>
    public enum CardType
    {
        [Display(Name = nameof(DomainMetadata.CardType_ToDo), ResourceType = typeof(DomainMetadata))]
        ToDo = 0,
        [Display(Name = nameof(DomainMetadata.CardType_Doing), ResourceType = typeof(DomainMetadata))]
        Doing = 1,
        [Display(Name = nameof(DomainMetadata.CardType_Done), ResourceType = typeof(DomainMetadata))]
        Done = 2,
    }
   
}
