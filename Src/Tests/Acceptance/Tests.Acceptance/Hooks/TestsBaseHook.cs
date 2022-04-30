using BoDi;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Hooks
{
    [Binding]
    public class TestsBaseHook
    {
        private readonly IObjectContainer _objectContainer;

        public TestsBaseHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }



        [BeforeScenario]
        public void InitialStage()
        {
            var cast = Cast.WhereEveryoneCan(new List<IAbility> { CallAnApi.At("https://localhost:44314/") });
            var stage = new Stage(cast);
            _objectContainer.RegisterInstanceAs(stage);
        }
    }
}
