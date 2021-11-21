using System;
using System.Linq.Expressions;

namespace Aids {
    public static class GetMember {
        public static string Name<TClass>(Expression<Func<TClass, object>> e)
            => Safe.Run(() => Name(e?.Body), string.Empty);

        public static string Name<TClass, TResult>(Expression<Func<TClass, TResult>> e)
            => Safe.Run(() => Name(e?.Body), string.Empty);
        
        public static string Name<TClass>(Expression<Action<TClass>> e)
            => Safe.Run(() => Name(e?.Body), string.Empty);

        public static string Name(Expression ex) => ex switch {
            MemberExpression member => name(member), 
            MethodCallExpression method => name(method),
            UnaryExpression operand => name(operand),
            _=> string.Empty
        };
        private static string name(MemberExpression e) => e?.Member.Name ?? string.Empty;
        private static string name(MethodCallExpression e) => e?.Method.Name ?? string.Empty;
        private static string name(UnaryExpression e) => e?.Operand switch {
                MemberExpression member => name(member),
                MethodCallExpression method => name(method),
                _ => string.Empty
            };
    }
}
