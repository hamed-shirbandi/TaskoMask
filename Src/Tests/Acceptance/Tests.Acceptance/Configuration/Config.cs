using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace TaskoMask.Tests.Acceptance.Configuration
{
    public static class Config
    {
        private static IConfiguration _configuration;
        public static string TestLevel;
        public static string BaseApiUrl;
        public static string BaseUiUrl;
        public static Assembly TestLevelAssembly;

        static Config()
        {
            _configuration = BuildConfiguration();
            TestLevel = _configuration["TestLevelToExecute"];
            BaseApiUrl = _configuration["BaseApiUrl"];
            BaseUiUrl = _configuration["BaseUiUrl"];
            TestLevelAssembly = GetTestLevelAssembly();
        }

        private static Assembly GetTestLevelAssembly()
        {
            if (TestLevel == "API-Level")
               return  Assembly.Load("TaskoMask.Tests.Acceptance.API");
            else
               return  Assembly.Load("TaskoMask.Tests.Acceptance.UI");
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                                //Copy from AdminPanel project during the build event
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                                .Build();
        }
    }
}
