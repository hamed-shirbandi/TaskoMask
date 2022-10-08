using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.Services.Owner.Infrastructure.CrossCutting.Mapper
{

    /// <summary>
    /// 
    /// </summary>
    public static class MapperExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(OwnerMappingProfile));
        }
    }
}
