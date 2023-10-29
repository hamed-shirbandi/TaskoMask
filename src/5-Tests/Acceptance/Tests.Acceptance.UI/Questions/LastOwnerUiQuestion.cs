using OpenQA.Selenium;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.Core.Models;
using TaskoMask.Tests.Acceptance.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.UI.Helpers;
using TaskoMask.Tests.Acceptance.UI.Suzianna;

namespace TaskoMask.Tests.Acceptance.UI.Questions;

public class LastOwnerUiQuestion : LastOwnerQuestion
{
    public LastOwnerUiQuestion() { }

    protected override Result<OwnerBasicInfoDto> GetLastOwner<T>(T actor)
    {
        var ability = actor.FindAbility<BrowseWebPage>();

        var dashboardUrl = ability.BaseUrl;
        ability.Driver.Navigate().GoToUrl(dashboardUrl);
        ability.Driver.FindElement(By.Id("update_user_profile")).Click();

        var updateFormExist = ability.Driver.WaitForElementToExist(By.Id("user_update_profile_form"));
        if (!updateFormExist)
            return Result.Failure<OwnerBasicInfoDto>();

        return Result.Success(
            new OwnerBasicInfoDto
            {
                Email = ability.Driver.FindElement(By.Id("user_profile_email")).GetAttribute("value"),
                DisplayName = ability.Driver.FindElement(By.Id("user_profile_displayname")).GetAttribute("value"),
            }
        );
    }
}
