﻿using MongoDB.Driver;
using System.Threading.Tasks;
using TaskoMask.Domain.DomainModel.Authorization.Data;
using TaskoMask.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Infrastructure.Data.Write.Repositories.Authorization
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        #region Fields

        protected readonly IMongoCollection<User> _users;


        #endregion

        #region Ctors

        public UserRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.GetCollection<User>();

        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByUserNameAsync(string userName)
        {
            return await _users.Find(e => e.UserName == userName).AnyAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _users.Find(e => e.UserName == userName).FirstOrDefaultAsync();
        }




        #endregion

        #region Private Methods



        #endregion
    }
}
