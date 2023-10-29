namespace TaskoMask.Services.Boards.Write.Api.Domain.Boards.Services;

/// <summary>
///
/// </summary>
public interface IBoardValidatorService
{
    /// <summary>
    /// Check if the name of the board is unique for its project
    /// </summary>
    bool BoardHasUniqueName(string boardId, string projectId, string boardName);
}
