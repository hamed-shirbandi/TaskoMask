using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Tests.Acceptance.Share.Helpers
{
    public static class Reflector
    {
        public static IDictionary<string, Type> GetScreenplayTypes(this Assembly assembly)
        {
            return assembly.GetExportedTypes()
                .Where(t => t.IsTask() || t.IsQuestion())
                .ToDictionary(t => t.BaseType.Name, t => t);
        }

        public static T GetInstanceOf<T>(this IDictionary<string, Type> types, object[] parameters)
        {
            var type = types[(typeof(T).Name)];
            return (T)Activator.CreateInstance(type, parameters);
        }


        public static bool IsTask(this Type type)
        {
            return type.BaseType.GetInterfaces().Contains(typeof(ITask));
        }


        public static bool IsQuestion(this Type type)
        {
            return type.BaseType.GetInterfaces().Contains(typeof(IQuestion<>));
        }
    }
}
