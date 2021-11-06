using MongoDB.Driver;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class UserRepository<TEntity> : BaseRepository<TEntity>, IUserRepository<TEntity> where TEntity:User
    {

        #region Fields

        protected readonly IMongoCollection<TEntity> _users;


        #endregion

        #region Ctors

        public UserRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.GetCollection<TEntity>(); 

        }

        #endregion

        #region Public Methods



        /// <summary>

        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> GetByUserNameAsync(string userName)
        {
            return await _users.Find(e => e.UserName == userName).FirstOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _users.Find(e => e.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }



        #endregion

        #region Private Methods



        #endregion
    }
}
