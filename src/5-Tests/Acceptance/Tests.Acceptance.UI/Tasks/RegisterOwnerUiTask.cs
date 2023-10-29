using OpenQA.Selenium;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;
using TaskoMask.Tests.Acceptance.UI.Helpers;
using TaskoMask.Tests.Acceptance.UI.Suzianna;

namespace TaskoMask.Tests.Acceptance.UI.Tasks;

public class RegisterOwnerUiTask : RegisterOwnerTask
{
    private string registerUrl;

    public RegisterOwnerUiTask(OwnerRegisterDto ownerRegisterDto)
        : base(ownerRegisterDto) { }

    protected override bool DoRegister<T>(T actor)
    {
        var ability = actor.FindAbility<BrowseWebPage>();

        registerUrl = $"{ability.BaseUrl}/register";
        ability.Driver.Navigate().GoToUrl(registerUrl);

        ability.Driver.FindElement(By.Id("Input_DisplayName")).SendKeys(OwnerRegisterDto.DisplayName);
        ability.Driver.FindElement(By.Id("Input_Email")).SendKeys(OwnerRegisterDto.Email);
        ability.Driver.FindElement(By.Id("Input_Password")).SendKeys(OwnerRegisterDto.Password);
        ability.Driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys(OwnerRegisterDto.Password);

        ability.Driver.FindElement(By.Id("registerBtn")).Click();

        return ability.Driver.WaitForElementToExist(By.Id("dashboard_page"));
    }
}
