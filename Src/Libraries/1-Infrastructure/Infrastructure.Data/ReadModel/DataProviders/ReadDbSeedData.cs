using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Linq;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class ReadDbSeedData
    {

        /// <summary>
        /// Sync sample data that is inserted from WriteDbSeedData.SeedSampleData
        /// </summary>
        public static void SyncSampleData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _writeDbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();
                var _readDbContext = serviceScope.ServiceProvider.GetService<IReadDbContext>();
                var _owners = _readDbContext.GetCollection<Owner>();
                var _organizations = _readDbContext.GetCollection<Organization>();
                var _projects = _readDbContext.GetCollection<Project>();
                var _boards = _readDbContext.GetCollection<Board>();
                var _cards = _readDbContext.GetCollection<Card>();
                var _tasks = _readDbContext.GetCollection<Task>();
                var _members = _readDbContext.GetCollection<Member>();

                var _ownerAggregate = _writeDbContext.GetCollection<Domain.WriteModel.Workspace.Owners.Entities.Owner>();
                var _boardAggregate = _writeDbContext.GetCollection<Domain.WriteModel.Workspace.Boards.Entities.Board>();
                var _taskAggregate = _writeDbContext.GetCollection<Domain.WriteModel.Workspace.Tasks.Entities.Task>();


                //Sync read db with write db
                if (!_owners.AsQueryable().Any() && _taskAggregate.AsQueryable().Any())
                {

                    #region Sync Owner Aggregate

                    var owners = _ownerAggregate.AsQueryable().ToList();
                    foreach (var owner in owners)
                    {
                        _owners.InsertOne(new Owner(owner.Id)
                        {
                            DisplayName = owner.DisplayName.Value,
                            Email = owner.Email.Value,
                            UserName = owner.Email.Value,
                            IsActive = true
                        });

                        foreach (var organization in owner.Organizations)
                        {
                            _organizations.InsertOne(new Organization(organization.Id)
                            {
                                Name = organization.Name.Value,
                                Description = organization.Description.Value,
                                OwnerId = owner.Id,
                            });


                            foreach (var project in organization.Projects)
                            {
                                _projects.InsertOne(new Project(project.Id)
                                {
                                    Name = organization.Name.Value,
                                    Description = organization.Description.Value,
                                    OrganizationId = organization.Id,
                                });
                            }
                        }
                    }


                    #endregion

                    #region Sync Board Aggregate

                    var boards = _boardAggregate.AsQueryable().ToList();

                    foreach (var board in boards)
                    {
                        var project = _projects.AsQueryable().FirstOrDefault(o => o.Id == board.ProjectId.Value);
                        _boards.InsertOne(new Board(board.Id)
                        {
                            Name = board.Name.Value,
                            Description = board.Description.Value,
                            ProjectId = board.ProjectId.Value,
                            OrganizationId = project.OrganizationId,
                        });

                        foreach (var card in board.Cards)
                        {
                            _cards.InsertOne(new Card(card.Id)
                            {
                                Name = card.Name.Value,
                                Type = card.Type.Value,
                                BoardId = board.Id,
                            });
                        }


                        foreach (var member in board.Members)
                        {
                            _members.InsertOne(new Member(member.Id)
                            {
                                OwnerId = member.OwnerId.Value,
                                AccessLevel = member.AccessLevel.Value,
                                BoardId=board.Id,
                                ProjectId=project.Id,
                                OrganizationId=project.OrganizationId,
                            });
                        }
                    }


                    #endregion

                    #region Sync Task Aggregate

                    var tasks = _taskAggregate.AsQueryable().ToList();

                    foreach (var task in tasks)
                    {
                        var board = _boardAggregate.AsQueryable().FirstOrDefault(o => o.Id == task.BoardId.Value);
                        var project = _projects.AsQueryable().FirstOrDefault(o => o.Id == board.ProjectId.Value);

                        _tasks.InsertOne(new Task(task.Id)
                        {
                            Title = task.Title.Value,
                            Description = task.Description.Value,
                            BoardId = task.BoardId.Value,
                            OrganizationId = project.OrganizationId,
                            CardId=task.CardId.Value,
                            ProjectId=project.Id
                        });

                    }


                    #endregion


                }

            }
        }

    }
}
