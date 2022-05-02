using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace TaskoMask.Tests.Acceptance.Share.Helpers
{
    public static class Config
    {
        private static IConfiguration _configuration;
        public static string TestLevel { get; private set; }
        public static string BaseApiUrl { get; private set; }
        public static string BaseUiUrl { get; private set; }
        public static Assembly TestLevelAssembly { get; private set; }


        static Config()
        {
            _configuration = BuildConfiguration();
            TestLevel = _configuration["TestLevelToExecute"];
            BaseApiUrl = _configuration["BaseApiUrl"];
            BaseUiUrl = _configuration["BaseUiUrl"];
            TestLevelAssembly = GetTestLevelAssembly();
        }



        /// <summary>
        /// 
        /// </summary>
        private static Assembly GetTestLevelAssembly()
        {
            if (TestLevel == "API-Level")
               return  Assembly.Load("TaskoMask.Tests.Acceptance.API");
            else
               return  Assembly.Load("TaskoMask.Tests.Acceptance.UI");
        }



        /// <summary>
        /// 
        /// </summary>
        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .AddJsonFile("appsettings.Staging.json", optional: true)
                                .AddJsonFile("appsettings.Development.json", optional: true)
                                .Build();
        }

    }
}
