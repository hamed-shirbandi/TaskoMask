using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Enumeration
{
    /// <summary>
    /// Enumeration class refactor from enum
    /// </summary>
    public class BoardMemberAccessLevel
    {
        public int Value { get; set; }
        [Display(Name = nameof(ContractsMetadata.BoardMemberAccessLevel_Reader), ResourceType = typeof(ContractsMetadata))]
        public static BoardMemberAccessLevel Reader { get { return new BoardMemberAccessLevel { Value = 0 }; } }
        [Display(Name = nameof(ContractsMetadata.BoardMemberAccessLevel_Writer), ResourceType = typeof(ContractsMetadata))]
        public static BoardMemberAccessLevel Writer { get { return new BoardMemberAccessLevel { Value = 1 }; } }
    }

    public class BoardCardType
    {
        public int Value { get; set; }
        [Display(Name = nameof(ContractsMetadata.CardType_Backlog), ResourceType = typeof(ContractsMetadata))]
        public static BoardCardType Backlog { get { return new BoardCardType { Value = 0 }; } }
        [Display(Name = nameof(ContractsMetadata.CardType_ToDo), ResourceType = typeof(ContractsMetadata))]
        public static BoardCardType ToDo { get { return new BoardCardType { Value = 1 }; } }
        [Display(Name = nameof(ContractsMetadata.CardType_Doing), ResourceType = typeof(ContractsMetadata))]
        public static BoardCardType Doing { get { return new BoardCardType { Value = 2 }; } }
        [Display(Name = nameof(ContractsMetadata.CardType_Done), ResourceType = typeof(ContractsMetadata))]
        public static BoardCardType Done { get { return new BoardCardType { Value = 3 }; } }
    }

    public class UserType
    {
        public int Value { get; set; }
        public static UserType Owner { get { return new UserType { Value = 0 }; } }
        public static UserType Operator { get { return new UserType { Value = 1 }; } }
    }