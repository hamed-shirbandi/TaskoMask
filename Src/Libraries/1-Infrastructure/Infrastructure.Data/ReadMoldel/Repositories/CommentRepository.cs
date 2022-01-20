using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.Contracts;
using TaskoMask.Infrastructure.Data.WriteMoldel.Repositories;

namespace TaskoMask.Infrastructure.Data.ReadMoldel.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        #region Fields

        private readonly IMongoCollection<Comment> _comments;

        #endregion

        #region Ctors

        public CommentRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _comments = dbContext.GetCollection<Comment>();
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion

    }
}
