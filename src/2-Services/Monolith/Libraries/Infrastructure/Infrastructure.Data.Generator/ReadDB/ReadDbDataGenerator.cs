using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.BuildingBlocks.Contracts.Enums;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Generator.ReadDB
{
    internal static class ReadDbDataGenerator
    {




        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Board> GenerateBoard()
        {
            var items = new List<Board>();
            for (int i = 1; i <= 2; i++)
            { 
                items.Add(new Board(i.ToString())
                {
                    Name = $"Board_{i}",
                    Description = $"Board_{i} test description",
                });
            }

            return items;
        }




        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Card> GenerateCard()
        {
            var items = new List<Card>();
            for (int i = 1; i <= 1; i++)
            {
                items.Add(new Card(i.ToString())
                {
                    Name = $"Card_{i}",
                    Type = BoardCardType.ToDo,
                });
            }
            return items;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Domain.DataModel.Entities.Task> GenerateTasks()
        {
            var items = new List<Domain.DataModel.Entities.Task>();
            for (int i = 1; i <= 2; i++)
            {
                items.Add(new Domain.DataModel.Entities.Task(i.ToString())
                {
                    Title = $"Task_Title_{i}",
                    Description = "This is a test content for this task!",
                });
            }
            return items;
        }

    }
}
