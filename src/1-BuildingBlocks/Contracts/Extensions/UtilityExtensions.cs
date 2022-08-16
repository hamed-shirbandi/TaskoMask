using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace TaskoMask.BuildingBlocks.Contracts.Extensions
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



        /// <summary>
        /// 
        /// </summary>
        public static string GetEnumDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }


    }
}
