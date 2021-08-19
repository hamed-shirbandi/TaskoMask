using MongoDB.Driver;
using System.Threading.Tasks;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        #region Fields
        private readonly IMongoCollection<User> _users;


        #endregion

        #region Ctors

        public UserRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.GetCollection<User>(); 

        }

        #endregion

        #region Public Methods


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
