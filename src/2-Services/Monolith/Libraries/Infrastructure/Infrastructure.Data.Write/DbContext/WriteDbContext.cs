using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class WriteDbContext : MongoDbContext, IWriteDbContext
    {
        #region Fields


        #endregion

        #region Ctors


        public WriteDbContext(IOptions<WriteDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            Owners = GetCollection<Owner>();
            Boards = GetCollection<Board>();
            Tasks = GetCollection<Task>();
            Operators = GetCollection<Operator>();
            Roles = GetCollection<Role>();
            Permissions = GetCollection<Permission>();
        }



        #endregion

        #region Properties

        public IMongoCollection<Owner> Owners { get; }
        public IMongoCollection<Board> Boards { get; }
        public IMongoCollection<Task> Tasks { get; }
        public IMongoCollection<Operator> Operators { get; }
        public IMongoCollection<Role> Roles { get; }
        public IMongoCollection<Permission> Permissions { get; }

        #endregion

    }
}
