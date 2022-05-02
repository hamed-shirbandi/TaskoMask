using Suzianna.Core.Screenplay;
using System;
using System.Collections.Generic;
using TaskoMask.Tests.Acceptance.Share.Helpers;

namespace TaskoMask.Tests.Acceptance.Screenplay
{
    public static class Factory
    {
        private static IDictionary<string,Type> _screenplayTypes;

        static Factory()
        {
            _screenplayTypes = Config.TestLevelAssembly.GetScreenplayTypes();
        }


        public static T CreateTask<T>(params object[] parameters) where T:ITask
        {
            return _screenplayTypes.GetInstanceOf<T>(parameters);
        }


        public static T CreateQuestion<T>(params object[] parameters)
        {
            return _screenplayTypes.GetInstanceOf<T>(parameters);
        }
    }
}
