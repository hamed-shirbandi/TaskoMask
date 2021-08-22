
namespace TaskoMask.Application.Core.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class UtilityExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static string ToLowerFirst(this string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

    }
}
