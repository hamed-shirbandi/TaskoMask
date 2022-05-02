using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Tests.Acceptance.UI.Suzianna
{
    public class BrowseWebPage : IAbility, IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public string BaseUrl { get; private set; }


        private BrowseWebPage(string baseUrl)
        {
            BaseUrl = baseUrl;
            Driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        public void Dispose()
        {
            Driver.Close();
            Driver?.Dispose();
        }

        public static BrowseWebPage At(string baseApiUrl)
        {
            return new BrowseWebPage(baseApiUrl);
        }

    }
}
