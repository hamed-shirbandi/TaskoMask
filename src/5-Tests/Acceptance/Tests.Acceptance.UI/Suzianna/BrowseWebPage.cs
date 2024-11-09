using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Suzianna.Core.Screenplay;

namespace TaskoMask.Tests.Acceptance.UI.Suzianna;

/// <summary>
/// This is an extension for Suzianna
/// Because it's not support working with web pages as an ability
/// </summary>
public class BrowseWebPage : IAbility, IDisposable
{
    public IWebDriver Driver { get; private set; }
    public string BaseUrl { get; private set; }

    private BrowseWebPage(string baseUrl)
    {
        BaseUrl = baseUrl;
        Driver = new ChromeDriver(Environment.CurrentDirectory);
    }

    public static BrowseWebPage At(string baseApiUrl)
    {
        return new BrowseWebPage(baseApiUrl);
    }

    public void Dispose()
    {
        Driver.Close();
        Driver?.Dispose();
    }
}
