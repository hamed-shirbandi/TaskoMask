using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Questions;

namespace TaskoMask.Tests.Acceptance.Core.Helpers;

internal static class Reflector
{
    /// <summary>
    /// Get Task and Question types from given assembly
    /// </summary>
    public static IDictionary<string, Type> GetScreenplayTypes(this Assembly assembly)
    {
        return assembly.GetExportedTypes().Where(t => t.IsTask() || t.IsQuestion()).ToDictionary(t => t.BaseType.Name, t => t);
    }

    /// <summary>
    ///
    /// </summary>
    public static T GetInstanceOf<T>(this IDictionary<string, Type> types, object[] parameters)
    {
        var type = types[typeof(T).Name];
        return (T)Activator.CreateInstance(type, parameters);
    }

    /// <summary>
    ///
    /// </summary>
    private static bool IsTask(this Type type)
    {
        return type.BaseType.GetInterfaces().Contains(typeof(ITask));
    }

    /// <summary>
    ///
    /// </summary>
    private static bool IsQuestion(this Type type)
    {
        return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQuestion<>));
    }
}
