using System;


namespace Aids
{
    public static class GetEnum
    {
        public static int Count<T>() => Count(typeof(T));
        public static int Count(Type type)
            => Safe.Run(() => Enum.GetValues(type).Length, -1);

        public static T ValueByIndex<T>(int i) => (T)ValueByIndex(typeof(T), i);
        public static T ValueByValue<T>(int i) => (T)ValueByValue(typeof(T), i);

        public static dynamic ValueByIndex(Type t, int i)
            => Safe.Run(() => {
                var v = Enum.GetValues(t);
                return v.GetValue(i);
            }, Def(t));
        public static dynamic ValueByValue(Type t, int i)
            => Safe.Run(() => {
                var values = Enum.GetValues(t);
                foreach (var e in values)
                {
                    var v = (int)e;
                    if (v == i) return e;
                }

                return Def(t);
            }, Def(t));

        private static object Def(Type t)
        {
            if (t.IsValueType) return Activator.CreateInstance(t);
            if (!t.IsEnum) return null;
            var v = Enum.GetValues(t);
            return v.GetValue(0);
        }
    }
}
