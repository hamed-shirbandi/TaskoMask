using System.Collections.Generic;

namespace TaskoMask.Domain.Core.Extensions
{
    public static class DataExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static bool Has<T>(this IList<string> collections, string name = "") 
        {
            var collection = name;
            if (string.IsNullOrEmpty(collection))
            {
                collection = typeof(T).Name;

                if (!collection.EndsWith("s"))  collection += "s";
            }

            return collections.Contains(collection);
        }


    }
}
