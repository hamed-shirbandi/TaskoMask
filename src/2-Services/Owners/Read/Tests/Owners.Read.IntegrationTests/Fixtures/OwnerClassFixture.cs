using AutoMapper;
using TaskoMask.Services.Owners.Read.Api.Domain;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    public class OwnerClassFixture : TestsBaseFixture
    {
        public IMapper Mapper;
        public OwnerReadDbContext DbContext;

        public OwnerClassFixture() : base(dbNameSuffix: nameof(OwnerClassFixture))
        {
            Mapper = GetRequiredService<IMapper>();
            DbContext = GetRequiredService<OwnerReadDbContext>();
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task SeedOwnerAsync(Owner owner)
        {
            await DbContext.Owners.InsertOneAsync(owner);
        }


    }
}