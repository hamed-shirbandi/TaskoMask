﻿using System.Threading.Tasks;

namespace TaskoMask.Domain.DomainModel.Workspace.Tasks.Services
{
    /// <summary>
    /// Some validations that need persistence layer to do
    /// </summary>
    public interface ITaskValidatorService
    {

        /// <summary>
        /// Check if the title of the task is unique for its board
        /// </summary>
        bool TaskHasUniqueName(string taskId, string boardId, string taskTitle);
        bool CanAddNewTaskToBoard(string boardId, int maxTasksCount);
    }
}
