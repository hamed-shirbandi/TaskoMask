using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Share.Enums
{


    /// <summary>
    /// 
    /// </summary>
    public enum BoardMemberAccessLevel
    {
        [Display(Name = nameof(DomainMetadata.BoardMemberAccessLevel_Reader), ResourceType = typeof(DomainMetadata))]
        Reader = 0,
        [Display(Name = nameof(DomainMetadata.BoardMemberAccessLevel_Writer), ResourceType = typeof(DomainMetadata))]
        Writer = 1,
    }



    /// <summary>
    /// 
    /// </summary>
    public enum BoardCardType
    {
        [Display(Name = nameof(DomainMetadata.CardType_ToDo), ResourceType = typeof(DomainMetadata))]
        ToDo = 0,
        [Display(Name = nameof(DomainMetadata.CardType_Doing), ResourceType = typeof(DomainMetadata))]
        Doing = 1,
        [Display(Name = nameof(DomainMetadata.CardType_Done), ResourceType = typeof(DomainMetadata))]
        Done = 2,
        [Display(Name = nameof(DomainMetadata.CardType_Backlog), ResourceType = typeof(DomainMetadata))]
        Backlog = 3,
    }
   
}
