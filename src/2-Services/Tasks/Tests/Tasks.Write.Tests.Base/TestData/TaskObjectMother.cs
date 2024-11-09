using System.Collections.Generic;
using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Entities;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Services;

namespace TaskoMask.Services.Tasks.Write.Tests.Base.TestData;

public static class TaskObjectMother
{
    /// <summary>
    ///
    /// </summary>

    public static Task CreateTask(ITaskValidatorService taskValidatorService)
    {
        return TaskBuilder
            .Init()
            .WithValidatorService(taskValidatorService)
            .WithTitle(TestDataGenerator.GetRandomName(10))
            .WithDescription(TestDataGenerator.GetRandomName(20))
            .WithCardId(ObjectId.GenerateNewId().ToString())
            .WithBoardId(ObjectId.GenerateNewId().ToString())
            .Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static Comment CreateComment()
    {
        return Comment.Create(content: TestDataGenerator.GetRandomName(20));
    }

    /// <summary>
    ///
    /// </summary>
    public static Task CreateTaskWithOneComment(ITaskValidatorService taskValidatorService)
    {
        var task = CreateTask(taskValidatorService);
        task.AddComment(CreateComment());
        task.ClearDomainEvents();
        return task;
    }

    /// <summary>
    ///
    /// </summary>
    public static List<Task> GenerateTasksList(ITaskValidatorService taskValidatorService, int number = 3)
    {
        var list = new List<Task>();

        while (number-- > 0)
            list.Add(CreateTask(taskValidatorService));

        return list;
    }
}
