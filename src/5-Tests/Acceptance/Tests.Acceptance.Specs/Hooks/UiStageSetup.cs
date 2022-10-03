using BoDi;
using Suzianna.Core.Screenplay;
using System.Collections.Generic;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.UI.Suzianna;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Specs.Hooks
{
    [Binding]
    public class UiStageSetup
    {
        private readonly IObjectContainer _objectContainer;
        private BrowseWebPage browseWebPage;
        public UiStageSetup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        /// <summary>
        /// This hook runs beafor each senario with UI-Level tag
        /// ************* Important point *************
        /// You always have to determine the tag before running acceptance tests
        /// If you use CLI do it like bellow
        /// > dotnet test myproject --filter Category=API-Level
        /// Or to run with Visual Studio
        /// You can select the tag in Traits list in Test Explorer
        /// </summary>
        [BeforeScenario(MagicKey.TestLevel.UI_Level)]
        public void StageSetup()
        {
            if (Config.TestLevel == MagicKey.TestLevel.UI_Level)
            {
                browseWebPage = BrowseWebPage.At(Config.WebsiteBaseUrl);
                var cast = Cast.WhereEveryoneCan(new List<IAbility> { browseWebPage });
                var stage = new Stage(cast);
                _objectContainer.RegisterInstanceAs(stage);
            }
        }




        /// <summary>
        /// This hook runs after each senario with UI-Level tag
        /// And close chrome driver
        /// </summary>
        [AfterScenario(MagicKey.TestLevel.UI_Level)]
        public void StageDrop()
        {
            if (Config.TestLevel == MagicKey.TestLevel.UI_Level)
            {
                browseWebPage.Dispose();
            }
        }
    }
}
