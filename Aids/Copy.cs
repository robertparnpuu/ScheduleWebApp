using Aids;
using System.Linq;

namespace Aids {
    public static class Copy {
        
        public static TTo Members<TFrom, TTo>(TFrom from, TTo to) =>
            Members(from, to, null);

        public static TTo Members<TFrom, TTo>(TFrom from, TTo to, params string[] exclude) {
            if (to is null) return default;
            if (from is null) return to;
            foreach (var property in from.GetType().GetProperties()) {
                var name = property.Name;
                if (exclude?.Contains(name) ?? false) continue;
                var p = to.GetType().GetProperty(name);
                if (p is null) continue;
                var v = property.GetValue(from);
                Safe.Run(() => p.SetValue(to, v));
            }

            return to;
        }
    }
}
