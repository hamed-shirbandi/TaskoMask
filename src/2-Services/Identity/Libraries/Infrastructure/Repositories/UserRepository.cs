using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Identity.Domain.Data;
using TaskoMask.Services.Identity.Domain.Entities;
using TaskoMask.Services.Identity.Infrastructure.DbContext;

namespace TaskoMask.Services.Identity.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        #region Fields

        protected readonly IMongoCollection<User> _users;


        #endregion

        #region Ctors

        public UserRepository(IIdentityDbContext dbContext) : base(dbContext)
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
