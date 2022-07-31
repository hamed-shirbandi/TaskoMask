
using TaskoMask.Infrastructure.Data.Generator.ReadDB;
using TaskoMask.Infrastructure.Data.Generator.WriteDB;

namespace TaskoMask.Infrastructure.Data.Generator
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
            ReadDbSeedData.SyncSampleDataWithWriteDB(serviceProvider);
        }

    }
}
