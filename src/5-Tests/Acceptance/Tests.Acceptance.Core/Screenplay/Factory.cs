using System;
using System.Collections.Generic;
using Suzianna.Core.Screenplay;
using TaskoMask.Tests.Acceptance.Core.Helpers;

namespace TaskoMask.Tests.Acceptance.Core.Screenplay;

/// <summary>
/// It is used to get dynamic instance from given base question/task from specified test level assembly (API or UI)
/// By using Factory, instead of repeating following code for each Task/Question:
///
/// if(TestLevelToExecute =="UI-Level")
///     return new LoginOwnerApiTask();
/// else if (TestLevelToExecute =="UI-Level")
///     return new LoginOwnerUiTask();
///
/// We simply use following code:
///
///     return Factory.CreateTask<LoginOwnerTask>();
///
/// </summary>
internal static class Factory
{
    private static readonly IDictionary<string, Type> _screenplayTypes;

    static Factory()
    {
        _screenplayTypes = Config.TestLevelAssembly.GetScreenplayTypes();
    }

    /// <summary>
    ///
    /// </summary>
    public static T CreateTask<T>(params object[] parameters)
        where T : ITask
    {
        return _screenplayTypes.GetInstanceOf<T>(parameters);
    }

    /// <summary>
    ///
    /// </summary>
    public static T CreateQuestion<T>(params object[] parameters)
    {
        return _screenplayTypes.GetInstanceOf<T>(parameters);
    }
}
