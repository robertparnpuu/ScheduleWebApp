using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aids {
    public static class GetClass {

        private static string Get => "get_";
        private static string Set => "set_";
        private static string Add => "add_";
        private static string Remove => "remove_";
        private static string Ctor => ".ctor";
        private static string Value => "value__";
        private static string Test => "+TestClass";
        public static List<MemberInfo> Members(Type type,
            BindingFlags f = PublicFlagsFor.All,
            bool clean = true) {
            if (type is null) return new List<MemberInfo>();
            var l = type.GetMembers(f).ToList();
            if (clean) RemoveSurrogates(l);
            return l;
        }
        public static List<PropertyInfo> Properties(Type type,
            BindingFlags f = PublicFlagsFor.All)
            => type?.GetProperties(f).ToList() ?? new List<PropertyInfo>();
        private static void RemoveSurrogates(IList<MemberInfo> l) {
            for (var i = l.Count; i > 0; i--) {
                var m = l[i - 1];
                if (!IsSurrogate(m)) continue;
                l.RemoveAt(i - 1);
            }
        }
        private static bool IsSurrogate(MemberInfo m) {
            var n = m.Name;
            if (string.IsNullOrEmpty(n)) return false;
            if (n.Contains(Get)) return true;
            if (n.Contains(Set)) return true;
            if (n.Contains(Add)) return true;
            if (n.Contains(Remove)) return true;
            if (n.Contains(Value)) return true;
            return n.Contains(Test) || n.Contains(Ctor);
        }
    }
}





