using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Enums
{


    /// <summary>
    /// 
    /// </summary>
    public enum BoardMemberAccessLevel
    {
        [Display(Name = nameof(ContractsMetadata.BoardMemberAccessLevel_Reader), ResourceType = typeof(ContractsMetadata))]
        Reader = 0,
        [Display(Name = nameof(ContractsMetadata.BoardMemberAccessLevel_Writer), ResourceType = typeof(ContractsMetadata))]
        Writer = 1,
    }



    /// <summary>
    /// 
    /// </summary>
    public enum BoardCardType
    {
        [Display(Name = nameof(ContractsMetadata.CardType_Backlog), ResourceType = typeof(ContractsMetadata))]
        Backlog = 0,
        [Display(Name = nameof(ContractsMetadata.CardType_ToDo), ResourceType = typeof(ContractsMetadata))]
        ToDo = 1,
        [Display(Name = nameof(ContractsMetadata.CardType_Doing), ResourceType = typeof(ContractsMetadata))]
        Doing = 2,
        [Display(Name = nameof(ContractsMetadata.CardType_Done), ResourceType = typeof(ContractsMetadata))]
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
