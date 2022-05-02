using BoDi;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Specs.Hooks
{
    [Binding]
    public class StageSetupUiHook
    {
        private readonly IObjectContainer _objectContainer;

        public StageSetupUiHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        /// <summary>
        /// This hook runs beafor each senario with UI-Level tag
        /// </summary>
        [BeforeScenario(MagicKey.TestLevel.UI_Level)]
        public void StageSetup()
        {
            if (Config.TestLevel == MagicKey.TestLevel.UI_Level)
            {
                //TODO: Setup selenium dirvers
            }
        }



        /// <summary>
        /// This hook runs beafor each senario with UI-Level tag
        /// </summary>
        [AfterScenario(MagicKey.TestLevel.UI_Level)]
        public void StageDrop()
        {
            if (Config.TestLevel == MagicKey.TestLevel.UI_Level)
            {
                //TODO: dispose selenium drivers
            }
        }
    }
}
