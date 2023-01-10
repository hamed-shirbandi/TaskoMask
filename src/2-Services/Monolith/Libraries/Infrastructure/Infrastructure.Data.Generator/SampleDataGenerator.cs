
using TaskoMask.Services.Monolith.Infrastructure.Data.Generator.ReadDB;
using TaskoMask.Services.Monolith.Infrastructure.Data.Generator.WriteDB;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Generator
{

    /// <summary>
    /// 
    /// </summary>
    public static class SampleDataGenerator
    {

        /// <summary>
        /// 
        /// </summary>
        public static void GenerateAndSeedSampleData(IServiceProvider serviceProvider)
        {
            WriteDbSeedData.SeedSampleData(serviceProvider);
        }

    }
}
