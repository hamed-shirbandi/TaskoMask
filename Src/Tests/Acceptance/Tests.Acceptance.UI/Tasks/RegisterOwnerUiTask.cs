using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;
using System;
using System.Threading;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Tasks;
using TaskoMask.Tests.Acceptance.UI.Suzianna;

namespace TaskoMask.Tests.Acceptance.UI.Tasks
{
    public class RegisterOwnerUiTask : RegisterOwnerTask
    {
        private string registerUrl;
        public RegisterOwnerUiTask(OwnerRegisterDto ownerRegisterDto) : base(ownerRegisterDto)
        {

        }


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

            return ExistElementInThePage(ability.Driver, By.Id("dashboard_page"));
        }


        private bool ExistElementInThePage(IWebDriver driver, By by)
        {
            try
            {
                driver.Wait(2500).ForElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
