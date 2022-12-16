using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace TaskoMask.Tests.Acceptance.Core.Helpers
{
    public static class Config
    {
        private static IConfiguration _configuration;
        public static string TestLevel { get; private set; }
        public static string ApiGatewayBaseUrl { get; private set; }
        public static string WebsiteBaseUrl { get; private set; }
        public static Assembly TestLevelAssembly { get; private set; }


        static Config()
        {
            _configuration = BuildConfiguration();
            TestLevel = _configuration["TestLevelToExecute"];
            ApiGatewayBaseUrl = _configuration["Url:ApiGateway"];
            WebsiteBaseUrl = _configuration["Url:Website"];
            TestLevelAssembly = GetTestLevelAssembly();
        }



        /// <summary>
        /// When tests run, you need to specify what type of test level must handle it
        /// If you want to run tests from UI level you must set UI-Level for TestLevelToExecute in appsettings
        /// Or set API-Level to run tests from API level
        /// </summary>
        private static Assembly GetTestLevelAssembly()
        {
            if (TestLevel == MagicKey.TestLevel.API_Level)
               return  Assembly.Load("TaskoMask.Tests.Acceptance.API");
            else // For "UI-Level"
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
