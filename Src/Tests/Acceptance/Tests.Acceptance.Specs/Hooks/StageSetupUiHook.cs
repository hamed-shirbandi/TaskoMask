using BoDi;
using Suzianna.Core.Screenplay;
using System.Collections.Generic;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TaskoMask.Tests.Acceptance.UI.Suzianna;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Specs.Hooks
{
    [Binding]
    public class StageSetupUiHook
    {
        private readonly IObjectContainer _objectContainer;
        private BrowseWebPage browseWebPage;
        public StageSetupUiHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        /// <summary>
        /// This hook runs beafor each senario with UI-Level tag
        /// And enable chrome driver
        /// </summary>
        [BeforeScenario(MagicKey.TestLevel.UI_Level)]
        public void StageSetup()
        {
            if (Config.TestLevel == MagicKey.TestLevel.UI_Level)
            {
                browseWebPage = BrowseWebPage.At(Config.BaseWebUrl);
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
