
namespace TaskoMask.BuildingBlocks.Test.TestData
{
    public static class TestDataGenerator
    {

        private static readonly Random _random = new();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string _alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";



        /// <summary>
        /// 
        /// </summary>
        public static string GetRandomName(int length)
        {
            return new string(Enumerable.Repeat(_alphabets, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }



        /// <summary>
        /// 
        /// </summary>
        public static string GetRandomEmail()
        {
            return $"{GetRandomName(10)}@taskomask.ir";
        }



        /// <summary>
        /// 
        /// </summary>
        public static string GetRandomString(int length)
        {
            return new string(Enumerable.Repeat(_chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
