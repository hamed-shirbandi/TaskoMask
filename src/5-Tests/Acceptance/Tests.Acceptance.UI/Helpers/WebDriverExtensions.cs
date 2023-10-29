using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace TaskoMask.Tests.Acceptance.UI.Helpers;

internal static class WebDriverExtensions
{
    public static bool WaitForElementToExist(this IWebDriver driver, By by, int millisecond = 5000)
    {
        try
        {
            driver.Wait(millisecond).ForElement(by).ToExist();
            return true;
        }
        catch (WebDriverTimeoutException ex)
        {
            if (ex.InnerException?.GetType() == typeof(NoSuchElementException))
                return false;
            else
                throw;
        }
    }
}
