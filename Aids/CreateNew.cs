using System;
using System.Collections.Generic;
using System.Reflection;

namespace Aids
{
    public static class CreateNew
    {
        public static T Instance<T>()
        {
            static T F()
            {
                var t = typeof(T);
                var o = Instance(t);

                return (o is null) ? default : (T)o;
            }
            var def = default(T);
            return Safe.Run(F, def);
        }
        public static object Instance(Type t)
        {
            return Safe.Run(() => {
                var constructor = GetConstructorInfo(t);

                if (constructor is null) return null;
                var parameters = constructor.GetParameters();
                var values = SetRandomParameters(parameters);
                return Invoke(constructor, values);
            }, null);
        }
        private static object Invoke(ConstructorInfo ci, object[] values)
        {
            return values.Length == 0 ? ci.Invoke(null) : ci.Invoke(values);
        }
        private static object[] SetRandomParameters(IEnumerable<ParameterInfo> parameters)
        {
            var values = new List<object>();
            foreach (var p in parameters)
            {
                var t = p.ParameterType;
                var value = GetRandom.ValueOf(t);
                values.Add(value);
            }
            return values.ToArray();
        }
        private static ConstructorInfo GetConstructorInfo(Type t)
        {
            var constructors = t?.GetConstructors();

            if (constructors == null) return null;
            return constructors.Length == 0 ? null : constructors[0];
        }
    }
}
