using System;
using System.Collections.Generic;

namespace LinqPagination
{
    public static class ActionDo
    {
        public static T Do<T>(this T me, Action<T> @do)
        {
            @do(me);
            return me;
        }

        public static T To<T>(this object me, Func<object, T> @to)
          => @to(me);

        public static IEnumerable<T> EachDo<T>(this IEnumerable<T> me, Action<T> @do)
        {
            foreach (var item in me)
                item.Do(@do);
            return me;
        }

        public static IEnumerable<T> EachTo<S,T>(this IEnumerable<S> me, Func<S, T> @to)
        {
            foreach (var item in me)
                yield return @to(item);
        }

        public static void ForByCount(this int count,Action<int> @do)
        {
            for (int i = 0; i < count; i++)
                @do(i);
        }
    }
}
