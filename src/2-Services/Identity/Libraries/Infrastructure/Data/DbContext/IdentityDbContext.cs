using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Infrastructure.Data.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class IdentityDbContext : MongoDbContext, IIdentityDbContext
    {
        #region Fields


        #endregion

        #region Ctors


        public IdentityDbContext(IOptions<MongoDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            Users = GetCollection<User>();
        }



        #endregion

        #region Properties

        public IMongoCollection<User> Users { get; }

        #endregion

    }
}
