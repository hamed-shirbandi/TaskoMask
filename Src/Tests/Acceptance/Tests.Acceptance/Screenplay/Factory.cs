using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Tests.Acceptance.Configuration;

namespace TaskoMask.Tests.Acceptance.Screenplay
{
    public static class Factory
    {
        private static IDictionary<string,Type> _types;

        static Factory()
        {
            _types = Config.TestLevelAssembly
                .GetExportedTypes()
                .Where(t=>t.IsTask()||t.IsQuestion())
                .ToDictionary(t=>t.BaseType.Name,t=>t);
        }


        public static T CreateTask<T>(params object[] parameters) where T:ITask
        {
            return GetInstanceOf<T>(parameters);
        }


        public static T CreateQuestion<T>(params object[] parameters)
        {
            return GetInstanceOf<T>(parameters);
        }


        private static T GetInstanceOf<T>(object[] parameters)
        {
            var type = _types[(typeof(T).Name)];
            return (T)Activator.CreateInstance(type, parameters);
        }


        private static bool IsTask(this Type type)
        {
            return type.BaseType.GetInterfaces().Contains(typeof(ITask));
        }


        private static bool IsQuestion(this Type type)
        {
            return type.BaseType.GetInterfaces().Contains(typeof(IQuestion<>));
        }
    }
}
