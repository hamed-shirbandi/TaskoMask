using System.Linq;

namespace TaskoMask.Domain.Core.Extensions
{
    public static class UtilityExtensions
    {

        public static object GetDisplayName<T>(this T obj) where T : class
        {
            return typeof(T).CustomAttributes.Any() ?
                typeof(T).CustomAttributes.First().ConstructorArguments.First().Value :
                nameof(T);
        }
    }
}
