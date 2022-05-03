using OpenQA.Selenium;
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

            ability.Driver.FindElement(By.Id("Input_ConfirmPassword")).Click();
            Thread.Sleep(5000);


            return !ability.Driver.FindElement(By.Id("dashboard-page")).Size.IsEmpty;
            //var sdsd= ability.Driver.FindElement(By.Id("dashboard-page"));
            //sdsd.ex

        }
    }
}
