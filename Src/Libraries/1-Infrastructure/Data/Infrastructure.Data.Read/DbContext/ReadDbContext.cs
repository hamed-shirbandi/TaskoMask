using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TaskoMask.Infrastructure.Data.Core.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class ReadDbContext : MongoDbContext, IReadDbContext
    {
        #region Fields



        #endregion

        #region Ctors


        public ReadDbContext(IConfiguration configuration)
            : base(configuration["Mongo:Read:Database"], configuration["Mongo:Read:Connection"])

        {

        }



        #endregion

        #region Public Methods



        #endregion

    }
}
