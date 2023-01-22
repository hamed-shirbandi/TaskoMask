using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class ReadDbContext : MongoDbContext, IReadDbContext
    {
        #region Fields



        #endregion

        #region Ctors


        public ReadDbContext(IOptions<ReadDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
        }



        #endregion

        #region Properties



        #endregion

    }
}
