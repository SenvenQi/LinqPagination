using System.Collections.Generic;

namespace LinqPagination
{
    public interface IPageResult
    {
        /// <summary>
        /// 数据源总条数
        /// </summary>
        int SourceCount { get; }
        /// <summary>
        /// 数据源总页数
        /// </summary>
        int PageCount { get; }
    }

    public interface IPageResult<T> : IPageResult
    {
        /// <summary>
        /// 分页结果集
        /// </summary>
        IList<T> Results { get; }
    }
}
