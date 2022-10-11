using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskoMask.BuildingBlocks.Infrastructure.EntityFramework
{
    public static class EFCoreExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabase<TContext>(this IServiceProvider serviceProvider) where TContext :DbContext
        {
            using var serviceScope = serviceProvider.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetService<TContext>();

            dbContext.Database.EnsureCreated();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void DropDatabase<TContext>(this IServiceProvider serviceProvider) where TContext : DbContext
        {
            using var serviceScope = serviceProvider.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetService<TContext>();

            dbContext.Database.EnsureDeleted();
        }

    }
}
