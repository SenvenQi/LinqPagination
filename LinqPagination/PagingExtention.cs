using System;
using System.Linq;
using System.Linq.Expressions;

namespace LinqPagination
{
    public static class PagingExtention
    {
        /// <summary>
        /// 分页扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>分页结果集</returns>
        public static IQueryable<T> Pagination<T>(this IQueryable<T> me, int pageIndex = 1, int pageSize = 10)
            => GetPaging<T>(pageIndex, pageSize).PagingBy(me);
        /// <summary>
        /// 分页默认方法第一页,每页50条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me">数据源</param>
        /// <returns>分页结果集</returns>
        public static IQueryable<T> Pagination<T>(this IQueryable<T> me)
            => GetPaging<T>().PagingBy(me);
        /// <summary>
        /// 分页扩展可添加过滤表达式集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="conditions">过滤表达式集合</param>
        /// <returns>分页结果集</returns>
        public static IQueryable<T> Pagination<T>(this IQueryable<T> me, int pageIndex = 1, int pageSize = 10, params Expression<Func<T, bool>>[] conditions)
        {
            var paging = GetPaging<T>(pageIndex, pageSize);
            paging.Conditions = conditions.ToList();
            return paging.PagingBy(me);
        }
        /// <summary>
        /// 分页默认方法第一页,每页50条数据 可添加过滤表达式集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me">数据源</param>
        /// <param name="conditions">过滤表达式集合</param>
        /// <returns>分页结果集</returns>
        public static IQueryable<T> Pagination<T>(this IQueryable<T> me, params Expression<Func<T, bool>>[] conditions)
        {
            var paging = GetPaging<T>();
            paging.Conditions = conditions.ToList();
            return paging.PagingBy(me);
        }
        /// <summary>
        /// 分页扩展可添加过滤表达式集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="conditions">过滤表达式集合</param>
        /// <returns>PageResult<T></returns>
        public static PageResult<T> PaginationToResult<T>(this IQueryable<T> me, int pageIndex = 1, int pageSize = 10, params Expression<Func<T, bool>>[] conditions)
        {
            var paging = GetPaging<T>(pageIndex, pageSize);
            paging.Conditions = conditions.ToList();
            var results = paging.PagingBy(me);
            return PageResult<T>.New(paging.AvailCnt, 
                paging.AvailCnt % paging.PageSize == 0 ? paging.AvailCnt / paging.PageSize : paging.AvailCnt / paging.PageSize + 1,
                paging.PageIndex,
                results.ToList());
        }
        /// <summary>
        /// 分页默认方法第一页,每页50条数据 可添加过滤表达式集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me">数据源</param>
        /// <param name="conditions">过滤表达式集合</param>
        /// <returns>PageResult<T></returns>
        public static PageResult<T> PaginationToResult<T>(this IQueryable<T> me, params Expression<Func<T, bool>>[] conditions)
        {
            var paging = GetPaging<T>();
            paging.Conditions = conditions.ToList();
            var results = paging.PagingBy(me);
            return PageResult<T>.New(paging.AvailCnt, 
                paging.AvailCnt % paging.PageSize == 0 ? paging.AvailCnt / paging.PageSize : paging.AvailCnt / paging.PageSize + 1,
                paging.PageIndex,
                results.ToList());
        }
        /// <summary>
        /// Paging<T>工厂方法动态获取Paging<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>IPaging<T></returns>
        private static IPaging<T> GetPaging<T>(int pageIndex, int pageSize)
        {
            var type = typeof(PageFactory<>).MakeGenericType(typeof(T));
            var constructorInfo = type.GetConstructor(new[] { typeof(int), typeof(int) });
            return (IPaging<T>)constructorInfo.Invoke(new object[] { pageSize, pageIndex });
        }
        /// <summary>
        /// Paging<T>工厂方法动态获取Paging<T> 默认值第一页50条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IPaging<T></returns>
        private static IPaging<T> GetPaging<T>()
        {
            var type = typeof(PageFactory<>).MakeGenericType(typeof(T));
            var constructorInfo = type.GetConstructor(Type.EmptyTypes);
            return (IPaging<T>)constructorInfo.Invoke(null);
        }
    }
}
