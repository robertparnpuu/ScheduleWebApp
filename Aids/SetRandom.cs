using System;
using System.Collections;
using System.Linq;

namespace Aids
{
    public static class SetRandom
    {

        public static void Values(object o)
        {
            if (o is null) return;
            if (o is IList list) SetValuesForList(list);
            else SetValuesForProperties(o);
        }
        private static void SetValuesForProperties(object o)
        {
            if (o is null) return;
            var t = o.GetType();
            var properties = t.GetProperties();
            foreach (var p in properties)
            {
                if (!p.CanWrite) continue;
                if (p.PropertyType.Name == t.Name) continue;
                var v = GetRandom.ValueOf(p.PropertyType);
                p.SetValue(o, v);
            }
        }

        private static void SetValuesForList(IList l)
        {
            if (l is null) return;
            var t = GetListElementsType(l);
            for (var c = 0; c <= GetRandom.UInt8(3, 5); c++)
            {
                var v = GetRandom.ValueOf(t);
                l.Add(v);
            }
        }
        private static Type GetListElementsType(IList list)
        {
            return Safe.Run(() => {
                var t = list.GetType();
                var types =
                    (from method in t.GetMethods()
                     where method.Name == "get_Item"
                     select method.ReturnType
                    ).Distinct().ToArray();
                return types[0];
            }, null);
        }
    }
}
