﻿using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.DomainModel.Authorization.Entities;

namespace TaskoMask.Infrastructure.Data.Generator.ReadDB
{
    internal static class ReadDbDataGenerator
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
