using BoDi;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using System.Collections.Generic;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Specs.Hooks
{
    [Binding]
    public class StageSetupApiHook
    {
        private readonly IObjectContainer _objectContainer;

        public StageSetupApiHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        /// <summary>
        /// This hook runs beafor each senario with API-Level tag
        /// </summary>
        [BeforeScenario("API-Level")]
        public void StageSetup()
        {
            var cast = Cast.WhereEveryoneCan(new List<IAbility> { CallAnApi.At(Config.BaseApiUrl) });
            var stage = new Stage(cast);
            _objectContainer.RegisterInstanceAs(stage);
        }
    }
}
