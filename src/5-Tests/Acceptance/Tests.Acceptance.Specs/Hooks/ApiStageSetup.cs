using BoDi;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using System.Collections.Generic;
using TaskoMask.Tests.Acceptance.Core.Helpers;
using TechTalk.SpecFlow;

namespace TaskoMask.Tests.Acceptance.Specs.Hooks
{
    [Binding]
    public class ApiStageSetup
    {
        private readonly IObjectContainer _objectContainer;

        public ApiStageSetup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        /// <summary>
        /// This hook runs beafor each senario with API-Level tag
        /// ************* Important point *************
        /// You always have to determine the tag before running acceptance tests
        /// If you use CLI do it like bellow
        /// > dotnet test myproject --filter Category=API-Level
        /// Or to run with Visual Studio
        /// You can select the tag in Traits list in Test Explorer
        /// </summary>
        [BeforeScenario(MagicKey.TestLevel.API_Level)]
        public void StageSetup()
        {
            if (Config.TestLevel== MagicKey.TestLevel.API_Level)
            {
                var cast = Cast.WhereEveryoneCan(new List<IAbility> { CallAnApi.At(Config.ApiGatewayBaseUrl) });
                var stage = new Stage(cast);
                _objectContainer.RegisterInstanceAs(stage);
            }
        }
    }
}
