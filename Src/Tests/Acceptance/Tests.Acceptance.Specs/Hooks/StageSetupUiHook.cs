using BoDi;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using System.Collections.Generic;
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



        [BeforeScenario("UI-Level")]
        public void StageSetup()
        {
            //TODO: Setup selenium dirvers
        }
    }
}
