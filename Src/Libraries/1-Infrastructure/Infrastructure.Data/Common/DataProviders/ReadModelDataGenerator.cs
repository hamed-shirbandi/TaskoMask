
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.WriteModel.Authorization.Entities;
using TaskoMask.Domain.WriteModel.Membership.Entities;

namespace TaskoMask.Infrastructure.Data.Common.DataProviders
{
    public static class ReadModelDataGenerator
    {

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Owner> GenerateOwner(IEnumerable<User> users)
        {
            var items = new List<Owner>();
            var i = 1;
            foreach (var user in users)
            {
                items.Add(new Owner(user.Id)
                {
                    DisplayName = $"Owner {i}",
                    Email = user.UserName,
                });

                i++;
            }

            return items;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Organization> GenerateOrganization()
        {
            var items = new List<Organization>();
            for (int i = 1; i <= 2; i++)
            {
                items.Add(new Organization(i.ToString())
                {
                    Name = $"Organization_{i}",
                    Description = $"Organization_{i} test description",
                });
            }
            return items;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Project> GenerateProject()
        {
            var items = new List<Project>();
            for (int i = 1; i < 2; i++)
            {
                items.Add(new Project(i.ToString())
                {
                    Name = $"Project_{i}",
                    Description = $"Project_{i} test description",
                });
            }

            return items;
        }



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
        public static IEnumerable<Task> GenerateTasks()
        {
            var items = new List<Task>();
            for (int i = 1; i <= 2; i++)
            {
                items.Add(new Task(i.ToString())
                {
                    Title = $"Task_Title_{i}",
                    Description = "This is a test content for this task!",
                });
            }
            return items;
        }

    }
}
