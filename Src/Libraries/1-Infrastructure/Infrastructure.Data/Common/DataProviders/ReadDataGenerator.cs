
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
    public static class ReadDataGenerator
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
                    Email = $"Owner{i}@example.com",
                });

                i++;
            }

            return items;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Organization> GenerateOrganization(IEnumerable<Owner> owners)
        {
            var items = new List<Organization>();
            var i = 1;
            foreach (var item in owners)
            {
                items.Add(new Organization
                {
                    OwnerId = item.Id,
                    Name = $"Organization_{i}",
                    Description = $"Organization_{i} test description",
                });

                i++;
            }

            return items;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Project> GenerateProject(IEnumerable<Organization> organizations)
        {
            var items = new List<Project>();
            var i = 1;
            foreach (var item in organizations)
            {
                items.Add(new Project
                {
                    OrganizationId = item.Id,
                    Name = $"Project_{i}",
                    Description = $"Project_{i} test description",
                });

                i++;
            }

            return items;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Board> GenerateBoard(IEnumerable<Project> projects)
        {
            var items = new List<Board>();
            var i = 1;
            foreach (var item in projects)
            {
                items.Add(new Board
                {
                    ProjectId = item.Id,
                    OrganizationId = item.OrganizationId,
                    Name = $"Board_{i}",
                    Description = $"Board_{i} test description",
                });

                i++;
            }

            return items;
        }




        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Card> GenerateCard(IEnumerable<Board> boards)
        {
            var items = new List<Card>();
            foreach (var item in boards)
            {
                for (int i = 1; i <= 4; i++)
                {
                    items.Add(new Card
                    {
                        BoardId = item.Id,
                        Name = $"Card_{i}",
                        Type = BoardCardType.ToDo,
                    });
                }
            }

            return items;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<Task> GenerateTasks(IEnumerable<Card> cards)
        {
            var items = new List<Task>();
            foreach (var item in cards)
            {
                for (int i = 1; i <= 5; i++)
                {
                    items.Add(new Task
                    {
                        CardId = item.Id,
                        BoardId = item.BoardId,
                        Title = $"Task_Title_{i}",
                        Description = "This is a test content for this task!",
                    });
                }
            }

            return items;
        }

    }
}
