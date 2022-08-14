using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TaskoMask.BuildingBlocks.Infrastructure.DbContext;

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


        public WriteDbContext(IConfiguration configuration)
            :base(configuration["Mongo:Write:Database"], configuration["Mongo:Write:Connection"])
        {

        }



        #endregion

        #region Public Methods



        #endregion

    }
}
