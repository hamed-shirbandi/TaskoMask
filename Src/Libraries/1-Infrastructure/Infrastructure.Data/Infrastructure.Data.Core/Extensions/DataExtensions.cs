using System.Collections.Generic;

namespace TaskoMask.Infrastructure.Data.Core.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static bool Has<TModel>(this IList<string> collections, string name = "") 
        {
            var collection = name;
            if (string.IsNullOrEmpty(collection))
            {
                collection = typeof(TModel).Name;

                if (!collection.EndsWith("s"))  collection += "s";
            }

            return collections.Contains(collection);
        }


    }
}
