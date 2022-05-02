using BoDi;
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
        [BeforeScenario("UI-Level")]
        public void StageSetup()
        {
            //TODO: Setup selenium dirvers
        }
    }
}
