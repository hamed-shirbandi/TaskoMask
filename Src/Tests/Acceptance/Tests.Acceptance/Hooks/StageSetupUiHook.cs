using BoDi;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using System.Collections.Generic;
using TaskoMask.Tests.Acceptance.Share.Helpers;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Hooks
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
            //var cast = Cast.WhereEveryoneCan(new List<IAbility> { CallAnApi.At(MagicKey.Configuration.API_Base_Url) });
            //var stage = new Stage(cast);
            //_objectContainer.RegisterInstanceAs(stage);
        }
    }
}
