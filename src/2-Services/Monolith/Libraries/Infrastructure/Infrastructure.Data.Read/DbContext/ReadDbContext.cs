using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class ReadDbContext : MongoDbContext, IReadDbContext
    {
        #region Fields



        #endregion

        #region Ctors


        public ReadDbContext(IOptions<ReadDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            Owners = GetCollection<Owner>();
            Organizations = GetCollection<Organization>();
            Projects = GetCollection<Project>();
            Boards = GetCollection<Board>();
            Cards = GetCollection<Card>();
            Tasks = GetCollection<Task>();
            Comments = GetCollection<Comment>();
            Activities = GetCollection<Activity>(nameof(Activities));
        }



        #endregion

        #region Properties

        public IMongoCollection<Owner> Owners { get; }
        public IMongoCollection<Organization> Organizations { get; }
        public IMongoCollection<Project> Projects { get; }
        public IMongoCollection<Board> Boards { get; }
        public IMongoCollection<Card> Cards { get; }
        public IMongoCollection<Task> Tasks { get; }
        public IMongoCollection<Comment> Comments { get; }
        public IMongoCollection<Activity> Activities { get; }


        #endregion

    }
}
