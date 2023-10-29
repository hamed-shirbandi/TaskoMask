using OpenQA.Selenium;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;
using TaskoMask.Tests.Acceptance.UI.Helpers;
using TaskoMask.Tests.Acceptance.UI.Suzianna;

namespace TaskoMask.Tests.Acceptance.UI.Tasks;

public class LoginOwnerUiTask : LoginOwnerTask
{
    private string loginUrl;

    public LoginOwnerUiTask(OwnerLoginDto ownerLoginDto)
        : base(ownerLoginDto) { }

    protected override bool DoLogin<T>(T actor)
    {
        var ability = actor.FindAbility<BrowseWebPage>();

        loginUrl = $"{ability.BaseUrl}/login";
        ability.Driver.Navigate().GoToUrl(loginUrl);

        ability.Driver.FindElement(By.Id("Input_UserName")).SendKeys(OwnerLoginDto.UserName);
        ability.Driver.FindElement(By.Id("Input_Password")).SendKeys(OwnerLoginDto.Password);

        ability.Driver.FindElement(By.Id("loginBtn")).Click();

        return ability.Driver.WaitForElementToExist(By.Id("dashboard_page"));
    }
}
