using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace LinqPagination
{
    public interface IPaging<T>:IPaging
    {
        /// <summary>
        /// 数据源过滤表达式集合
        /// </summary>
        IList<Expression<Func<T, bool>>> Conditions { get; set; }
        /// <summary>
        /// 运行分页
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        IQueryable<T> PagingBy(IQueryable<T> source);
        /// <summary>
        /// 添加where条件
        /// </summary>
        /// <param name="predicate"></param>
        void Add(Expression<Func<T, bool>> predicate);
    }
}
