using OpenQA.Selenium;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
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
            var element = ability.Driver.FindElement(By.Id("Input_DisplayName"));

            Thread.Sleep(10000);
            return true; 
        }
    }
}
