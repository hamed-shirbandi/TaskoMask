
using TaskoMask.Infrastructure.Data.Generator.ReadDB;

namespace TaskoMask.Infrastructure.Data.Generator.WriteDB
{

    /// <summary>
    /// 
    /// </summary>
    public static class SampleDataGenerator
    {

        /// <summary>
        /// 
        /// </summary>
        public static void GenerateAndSeed(IServiceProvider serviceProvider)
        {
            WriteDbSeedData.SeedSampleData(serviceProvider);
            ReadDbSeedData.SyncSampleDataWithWriteDB(serviceProvider);
        }

    }
}
