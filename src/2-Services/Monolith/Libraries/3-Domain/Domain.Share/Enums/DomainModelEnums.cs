using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Domain.Share.Enums
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
        [Display(Name = nameof(DomainMetadata.CardType_Backlog), ResourceType = typeof(DomainMetadata))]
        Backlog = 0,
        [Display(Name = nameof(DomainMetadata.CardType_ToDo), ResourceType = typeof(DomainMetadata))]
        ToDo = 1,
        [Display(Name = nameof(DomainMetadata.CardType_Doing), ResourceType = typeof(DomainMetadata))]
        Doing = 2,
        [Display(Name = nameof(DomainMetadata.CardType_Done), ResourceType = typeof(DomainMetadata))]
        Done = 3,

    }


    /// <summary>
    /// 
    /// </summary>
    public enum UserType
    {
        Owner = 0,
        Operator = 1
    }

}
