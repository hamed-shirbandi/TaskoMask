using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class OwnerReadDbContext : MongoDbContext
    {
        #region Fields


        #endregion

        #region Ctors


        public OwnerReadDbContext(IOptions<MongoDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            Owners = GetCollection<Owner>();
            Organizations = GetCollection<Organization>();
            Projects = GetCollection<Project>();
        }



        #endregion

        #region Properties

        public IMongoCollection<Owner> Owners { get; }
        public IMongoCollection<Organization> Organizations { get; }
        public IMongoCollection<Project> Projects { get; }

        #endregion

    }
}
