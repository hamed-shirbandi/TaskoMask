using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class UserBaseRepository<TEntity> : BaseRepository<TEntity>, IUserBaseRepository<TEntity> where TEntity:User
    {

        #region Fields

        private readonly IMongoCollection<User> _users;


        #endregion

        #region Ctors

        public UserBaseRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.GetCollection<User>(); 

        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public virtual async System.Threading.Tasks.Task CreateAsync(TEntity entity)
        {
            await _users.OfType<TEntity>().InsertOneAsync(entity);
        }




        /// <summary>
        /// 
        /// </summary>
        public virtual async System.Threading.Tasks.Task UpdateAsync(TEntity entity)
        {
            await _users.OfType<TEntity>().ReplaceOneAsync(p => p.Id == entity.Id, entity, new ReplaceOptions() { IsUpsert = false });
        }




        /// <summary>
        /// 
        /// </summary>
        public virtual async System.Threading.Tasks.Task DeleteAsync(string id)
        {
            await _users.OfType<TEntity>().DeleteOneAsync(p => p.Id == id);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await _users.OfType<TEntity>().Find(e => e.Id == id).FirstOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _users.OfType<TEntity>().AsQueryable().ToListAsync();

        }




        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<long> CountAsync()
        {
            return await _users.OfType<TEntity>().CountDocumentsAsync(f => true);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> GetByUserNameAsync(string userName)
        {
            return await _users.OfType<TEntity>().Find(e => e.UserName == userName).FirstOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _users.OfType<TEntity>().Find(e => e.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }



        #endregion

        #region Private Methods



        #endregion
    }
}
