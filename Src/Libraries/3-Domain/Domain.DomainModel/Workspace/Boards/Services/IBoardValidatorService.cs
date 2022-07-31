
namespace TaskoMask.Domain.DomainModel.Workspace.Boards.Services
{
    /// <summary>
    /// Some validations that need persistence layer to do
    /// </summary>
    public interface IBoardValidatorService
    {

        /// <summary>
        /// Check if the name of the board is unique for its project
        /// </summary>
        bool BoardHasUniqueName(string boardId, string projectId, string boardName);


    }
}
