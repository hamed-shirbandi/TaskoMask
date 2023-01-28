using TaskoMask.Services.Tasks.Write.Domain.Entities;
using TaskoMask.Services.Tasks.Write.Domain.Services;

namespace TaskoMask.Services.Tasks.Write.Tests.Base.TestData
{
    public class TaskBuilder
    {
        public ITaskValidatorService ValidatorService { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string CardId { get; private set; }
        public string BoardId { get; private set; }



        private TaskBuilder()
        {
        }



        public static TaskBuilder Init()
        {
            return new TaskBuilder();
        }



        public TaskBuilder WithValidatorService(ITaskValidatorService validatorService)
        {
            ValidatorService = validatorService;
            return this;
        }



        public TaskBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }



        public TaskBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }



        public TaskBuilder WithCardId(string cardId)
        {
            CardId = cardId;
            return this;
        }



        public TaskBuilder WithBoardId(string boardId)
        {
            BoardId = boardId;
            return this;
        }



        public Task Build()
        {
            var task = Task.AddTask(Title, Description, CardId, BoardId,ValidatorService);
            task.ClearDomainEvents();
            return task;
        }


    }
}
